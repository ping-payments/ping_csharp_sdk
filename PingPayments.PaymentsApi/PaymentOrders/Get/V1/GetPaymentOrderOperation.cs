using PingPayments.Shared.Helpers;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using static System.Net.HttpStatusCode;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using PingPayments.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public class GetPaymentOrderOperation : OperationBase<Guid, PaymentOrderResponse>
    {
        public GetPaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

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