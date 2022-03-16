using PaymentsApiSdk.Payments.InitiatePayment.Request;
using PaymentsApiSdk.Payments.InitiatePayment.Response;
using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentsApiSdk.Payments.InitiatePayment
{
    public class InitiatePaymentEndpoint
    {
        private readonly HttpClient _httpClient;

        public InitiatePaymentEndpoint(Guid tenantId, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("tenant_id", tenantId.ToString());
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static Uri GetRequestUri(Guid orderId) => new Uri($"api/v1/payment_orders/{orderId}/payments");

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
            var postBody = JsonSerializer.Serialize(initiatePaymentRequest);
            var uri = GetRequestUri(orderId);
            var content = new StringContent(postBody, Encoding.UTF8, "application/json");
            using var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri,
                Content = content
            };
            using var response = await _httpClient.SendAsync(httpRequestMessage);
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
                        true,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
            return initiatePaymentResponse;
        }
    }
}
