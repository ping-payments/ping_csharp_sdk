using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentsApi.Payments.Stop.V1
{
    public class StopOperation : OperationBase<(Guid orderId, Guid paymentId), EmptyResponse>
    {
        public StopOperation(HttpClient httpClient) : base(httpClient) { }
        public override async Task<EmptyResponse> ExecuteRequest((Guid orderId, Guid paymentId) request) =>
            await BaseExecute(PUT, $"api/v1/payment_orders/{request.orderId}/payments/{request.paymentId}/stop", request, await ToJson(new { }));

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, Guid paymentId) _) =>
        hrm.StatusCode switch
        {
            NoContent => EmptyResponse.Successful(hrm.StatusCode),
            _ => await ToEmptyError(hrm)
        };
    }
}
