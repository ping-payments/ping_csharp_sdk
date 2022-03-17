using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Initiate.Response;
using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.Payments.Initiate
{
    public class Initiate
    {
        private readonly HttpClient _httpClient;

        public Initiate(Guid tenantId, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("tenant_id", tenantId.ToString());
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string GetRequestUri(Guid orderId) => $"api/v1/payment_orders/{orderId}/payments";

        public static T? Deserialize<T>(string responseBody)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(responseBody);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public async Task<InitiatePaymentResponse> InitiatePayment(Guid orderId, InitiatePaymentRequest initiatePaymentRequest)
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(),
                    new ProviderMethodParametersJsonConvert()
                }
            };
            var postBody = JsonSerializer.Serialize(initiatePaymentRequest, options);
            var uri = GetRequestUri(orderId);
            var content = new StringContent(postBody, Encoding.UTF8, "application/json");            
            using var response = await _httpClient.PostAsync(uri, content);
            var statusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
            var isSuccesful = statusCode == HttpStatusCode.OK;
            var initiatePaymentResponse = statusCode switch
            {
                HttpStatusCode.OK =>
                    new InitiatePaymentResponse
                    (
                        (int)statusCode,
                        true,
                        Deserialize<InitiatePaymentResponseBody>(responseBody)
                    ),
                _ =>
                    new InitiatePaymentResponse
                    (
                        (int)statusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
            return initiatePaymentResponse;
        }
    }
}
