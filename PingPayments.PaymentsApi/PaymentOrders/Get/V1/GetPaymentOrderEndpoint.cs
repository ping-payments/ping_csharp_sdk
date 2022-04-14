using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public class GetPaymentOrderEndpoint : TenantEndpointBase<Guid, PaymentOrderResponse>
    {
        public GetPaymentOrderEndpoint(HttpClient httpClient, Guid tenantId) : base(httpClient, tenantId) { }

        protected override JsonSerializerOptions JsonSerializerOptions => new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
            }
        };

        public override async Task<PaymentOrderResponse> ExecuteRequest(Guid orderId) => 
            await BaseExecute(GET, $"api/v1/payment_orders/{orderId}", orderId);

        protected override async Task<PaymentOrderResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _)
        {
            var responseBody = await hrm.Content.ReadAsStringAsyncMemoized();
            var response = hrm.StatusCode switch
            {
                OK => PaymentOrderResponse.Succesful(hrm.StatusCode, await Deserialize<PaymentOrder>(responseBody), responseBody),
                _ => await ToError(hrm)
            };
            return response;
        }

        protected async Task<PaymentOrderResponse> ToError(HttpResponseMessage hrm) =>
            PaymentOrderResponse.Failure
            (
                hrm.StatusCode,
                await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()),
                await hrm.Content.ReadAsStringAsyncMemoized()
            );
    }
}