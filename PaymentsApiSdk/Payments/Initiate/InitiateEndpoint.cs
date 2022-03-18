using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Initiate.Response;
using PaymentsApiSdk.Shared;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaymentsApiSdk.Payments.Initiate
{
    public class InitiateEndpoint : 
        TenantEndpointBase<(Guid orderId, InitiatePaymentRequest initiatePaymentRequest), InitiatePaymentResponse>
    {
        public InitiateEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters = 
            { 
                new JsonStringEnumConverter(),
                new ProviderMethodParametersJsonConvert()
            }
        };

        public override async Task<InitiatePaymentResponse> Action((Guid orderId, InitiatePaymentRequest initiatePaymentRequest) request) =>
            await Execute
            (
                $"api/v1/payment_orders/{request.orderId}/payments",
                RequestTypeEnum.POST,
                new StringContent(Serialize(request.initiatePaymentRequest), Encoding.UTF8, "application/json")
            );

        protected override async Task<InitiatePaymentResponse> HttpResponseToResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            return hrm.StatusCode switch
            {
                HttpStatusCode.OK =>
                    new InitiatePaymentResponse
                    (
                        (int)hrm.StatusCode,
                        true,
                        Deserialize<InitiatePaymentResponseBody>(responseBody)
                    ),
                _ =>
                    new InitiatePaymentResponse
                    (
                        (int)hrm.StatusCode,
                        false,
                        Deserialize<ErrorResponseBody>(responseBody)
                    )
            };
        }
    }
}
