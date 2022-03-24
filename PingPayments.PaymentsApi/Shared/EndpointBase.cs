using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Shared
{
    public abstract class EndpointBase<Request, Response>
    {
        protected readonly HttpClient _httpClient;

        protected EndpointBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var json = new MediaTypeWithQualityHeaderValue("application/json");
            if (!_httpClient.DefaultRequestHeaders.Accept.Contains(json))
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(json);
            }
        }

        protected virtual JsonSerializerOptions JsonSerializerOptions => new() { Converters = { new JsonStringEnumConverter() } };

        protected abstract Task<Response> ParseHttpResponse(HttpResponseMessage response);

        public abstract Task<Response> ExecuteRequest(Request request);

        protected T? Deserialize<T>(string body)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(body, JsonSerializerOptions);
            }
            catch
            {
                return default;
            }
        }

        protected string Serialize<T>(T model) => JsonSerializer.Serialize(model, JsonSerializerOptions);

        protected StringContent ToJson<T>(T bodyObject) => new(Serialize(bodyObject), Encoding.UTF8, "application/json");

        protected async Task<Response> BaseExecute(RequestTypeEnum requestType, string url, HttpContent? content = null)
        {            
            using var response = requestType switch
            {
                RequestTypeEnum.POST => await _httpClient.PostAsync(url, content),
                RequestTypeEnum.PUT => await _httpClient.PutAsync(url, content),
                RequestTypeEnum.GET => await _httpClient.GetAsync(url),
                _ => throw new NotImplementedException()
            };
            return await ParseHttpResponse(response);
        }
    }
}
