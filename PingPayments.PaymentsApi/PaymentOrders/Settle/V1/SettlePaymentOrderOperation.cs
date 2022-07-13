using PingPayments.Shared.Helpers;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Settle.V1
{
    public class SettlePaymentOrderOperation : OperationBase<Guid, EmptyResponse>
    {
        public SettlePaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(Guid orderId) => 
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{orderId}/settle",
                orderId,
                await ToJson(new { })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _) => hrm.StatusCode switch
        {
            NoContent => EmptyResponse.Succesful(hrm.StatusCode),
            _ => EmptyResponse.Failure(hrm.StatusCode, await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()), await hrm.Content.ReadAsStringAsyncMemoized())
        };
    }
}