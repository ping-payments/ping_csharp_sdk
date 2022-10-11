using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Split.V1
{
    public class SplitPaymentOrderOperation : OperationBase<(Guid orderId, bool fastForward), EmptyResponse>
    {
        public SplitPaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid orderId, bool fastForward) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{request.orderId}/split",
                request,
                await ToJson(new { fast_forward = request.fastForward })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, bool fastForward) _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}