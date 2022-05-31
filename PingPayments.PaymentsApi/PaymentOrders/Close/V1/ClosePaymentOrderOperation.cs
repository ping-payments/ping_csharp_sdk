using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.PaymentsApi.Shared.RequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.PaymentOrders.Close.V1
{
    public class ClosePaymentOrderOperation : OperationBase<Guid, EmptyResponse>
    {
        public ClosePaymentOrderOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest(Guid orderId) => 
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{orderId}/close",
                orderId,
                await ToJson(new { })
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, Guid _) => 
            hrm.StatusCode switch
            {
                NoContent => EmptyResponse.Succesful(hrm.StatusCode),
                _ => 
                    EmptyResponse.Failure
                    (
                        hrm.StatusCode, 
                        await Deserialize<ErrorResponseBody>(await hrm.Content.ReadAsStringAsyncMemoized()), 
                        await hrm.Content.ReadAsStringAsyncMemoized()
                    )
            };
    }
}