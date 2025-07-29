using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PingPayments.Shared.Helpers
{
    internal class GenericList<T> where T : class
    {
        private readonly HttpClient _httpClient;
        protected virtual JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        public GenericList(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Iterates through paginated results and returns a custom result using the provided factory.
        /// </summary>
        /// <typeparam name="TResult">The result type to return.</typeparam>
        /// <param name="baseUrl">The initial URL to request.</param>
        /// <param name="resultFactory">
        /// A function that takes (isSuccess, statusCode, data, rawBody, error) and returns TResult.
        /// </param>
        public async Task<TResult> GetTListAsync<TResult>(
            string baseUrl,
            Func<bool, HttpStatusCode, List<T>, string, ErrorResponseBody?, TResult> resultFactory)
        {
            var result = new List<T>();
            string? nextUrl = baseUrl?.TrimEnd('&');
            HttpStatusCode lastStatusCode = HttpStatusCode.OK;
            string lastRawBody = string.Empty;

            while (!string.IsNullOrEmpty(nextUrl))
            {
                using var response = await _httpClient.GetAsync(nextUrl);
                lastStatusCode = response.StatusCode;
                lastRawBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    ErrorResponseBody? error = JsonSerializer.Deserialize<ErrorResponseBody>(lastRawBody, JsonSerializerOptions);
                    return resultFactory(false, lastStatusCode, result, lastRawBody, error);
                }

                var resultObj = JsonSerializer.Deserialize<GenericTransfer<T>>(lastRawBody, JsonSerializerOptions);
                if (resultObj?.Data != null)
                    result.AddRange(resultObj.Data);

                nextUrl = resultObj?.PaginationLinks.Next?.Href;
            }

            return resultFactory(true, lastStatusCode, result, lastRawBody, null);
        }
    }
}
