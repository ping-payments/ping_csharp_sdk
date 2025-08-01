﻿using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PingPayments.Shared
{
    public abstract class OperationBase<Request, Response>
    {
        protected readonly HttpClient _httpClient;

        protected OperationBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var json = new MediaTypeWithQualityHeaderValue("application/json");
            if (!_httpClient.DefaultRequestHeaders.Accept.Contains(json))
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(json);
            }
            _httpClient.DefaultRequestHeaders.Add("x-api-version", "2025-03-06");
        }

        protected virtual JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        protected abstract Task<Response> ParseHttpResponse(HttpResponseMessage response, Request request);

        public abstract Task<Response> ExecuteRequest(Request request);

        protected async Task<T?> Deserialize<T>(string body) => await Deserialize<T>(body, JsonSerializerOptions);

        protected static async Task<T?> Deserialize<T>(string body, JsonSerializerOptions jsonSerializerOptions)
        {
            try
            {
                using var ms = new MemoryStream(Encoding.UTF8.GetBytes(body));
                return await JsonSerializer.DeserializeAsync<T>(ms, jsonSerializerOptions);
            }
            catch(Exception ex)
            {
                return default;
            }
        }

        protected static async Task<string> Serialize<T>(T model, JsonSerializerOptions jsonSerializerOptions)
        {
            using var ms = new MemoryStream();
            await JsonSerializer.SerializeAsync(ms, model, jsonSerializerOptions);
            ms.Position = 0;
            using var reader = new StreamReader(ms);
            var json = await reader.ReadToEndAsync();
            return json;
        }

        protected async Task<StringContent> ToJson<T>(T bodyObject) => new(await Serialize(bodyObject, JsonSerializerOptions), Encoding.UTF8, "application/json");

        protected async Task<Response> BaseExecute(HttpRequestTypeEnum requestType, string url, Request request, HttpContent? content = null)
        {
            using var response = requestType switch
            {
                POST => await _httpClient.PostAsync(url, content),
                PUT => await _httpClient.PutAsync(url, content),
                GET => await _httpClient.GetAsync(url),
                DELETE => await _httpClient.DeleteAsync(url, content),
                _ => throw new NotImplementedException()
            };
            return await ParseHttpResponse(response, request);
        }

        protected async Task<EmptyResponse> ToEmptyError(HttpResponseMessage hrm) =>
            EmptyResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );

        /// <summary>
        /// Iterates through paginated results and returns a custom result using the provided factory.
        /// </summary>
        /// <typeparam name="T">The type of the data in the paginated response.</typeparam>
        /// <typeparam name="TResult">The result type to return.</typeparam>
        /// <param name="baseUrl">The initial URL to request.</param>
        /// <param name="resultFactory">
        /// A function that takes (isSuccess, statusCode, data, rawBody, error) and returns TResult.
        /// </param>
        protected async Task<TResult> GetPaginatedListAsync<T, TResult>(
            string baseUrl,
            Func<bool, HttpStatusCode, List<T>, string, ErrorResponseBody?, TResult> resultFactory)
            where T : class
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
                    ErrorResponseBody? error = null;
                    try
                    {
                        error = await Deserialize<ErrorResponseBody>(lastRawBody);
                    }
                    catch { }
                    return resultFactory(false, lastStatusCode, result, lastRawBody, error);
                }

                var resultObj = await Deserialize<GenericTransfer<T>>(lastRawBody);
                if (resultObj?.Data != null)
                    result.AddRange(resultObj.Data);

                nextUrl = resultObj?.PaginationLinks.Next?.Href;
            }

            return resultFactory(true, lastStatusCode, result, lastRawBody, null);
        }
    }
}
