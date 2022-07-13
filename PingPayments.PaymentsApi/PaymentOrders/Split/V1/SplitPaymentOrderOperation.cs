using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Split.V1
{
    public class SplitPaymentOrderOperation : OperationBase<Guid, EmptyResponse>
    {
        public SplitPaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(Guid orderId) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{orderId}/split",
                orderId,
                await ToJson(new { })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _) =>
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Succesful(hrm.StatusCode),
                _ => await ToEmptyError(hrm)
            };
    }
}