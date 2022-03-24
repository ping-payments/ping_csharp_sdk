using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.Initiate.V1
{
    public class InitiateEndpoint : TenantEndpointBase<(Guid orderId, InitiatePaymentRequest initiatePaymentRequest), InitiatePaymentResponse>
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

        public override async Task<InitiatePaymentResponse> ExecuteRequest((Guid orderId, InitiatePaymentRequest initiatePaymentRequest) request) =>
            await BaseExecute
            (
                POST,
                $"api/v1/payment_orders/{request.orderId}/payments",
                ToJson(request.initiatePaymentRequest)
            );

        protected override async Task<InitiatePaymentResponse> ParseHttpResponse(HttpResponseMessage hrm)
        {
            var responseBody = await hrm.Content.ReadAsStringAsync();
            var parsedResponse = hrm.StatusCode switch
            {
                OK => InitiatePaymentResponse.Succesful(hrm.StatusCode, Deserialize<InitiatePaymentResponseBody>(responseBody)),
                _ => InitiatePaymentResponse.Failure(hrm.StatusCode, Deserialize<ErrorResponseBody>(responseBody))
            };
            return parsedResponse;
        }
    }
}
