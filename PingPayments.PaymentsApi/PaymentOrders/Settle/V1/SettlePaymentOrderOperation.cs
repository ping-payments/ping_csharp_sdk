using PingPayments.Shared;
using PingPayments.Shared.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Settle.V1
{
    public class SettlePaymentOrderOperation : OperationBase<(Guid orderId, bool fastForward), EmptyResponse>
    {
        public SettlePaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid orderId, bool fastForward) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{request.orderId}/settle",
                request,
                await ToJson(new { fast_forward = request.fastForward })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, bool fastForward) _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => EmptyResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()), await hrm.Content.ReadAsStringAsyncMemoized())
            };
    }
}