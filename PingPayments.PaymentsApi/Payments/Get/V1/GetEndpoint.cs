using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public class GetEndpoint : TenantEndpointBase<(Guid orderId, Guid paymentId), PaymentResponse>
    {
        public GetEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentResponse> ExecuteRequest((Guid orderId, Guid paymentId) request) =>
            await BaseExecute(GET, $"api/v1/payment_orders/{request.orderId}/payments/{request.paymentId}", request);

        protected override async Task<PaymentResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, Guid paymentId) _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentResponse.Succesful(hrm.StatusCode, await Deserialize<PaymentResponseBody>(responseBody), responseBody),
                _ => PaymentResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(responseBody), responseBody)
            };
            return response;
        }
    }
}
