using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;

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
    }
}
