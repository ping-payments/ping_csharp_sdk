using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;

namespace PingPayments.PaymentsApi.Payments.Update.V1
{
    public class UpdateOperation : OperationBase<(Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest), EmptyResponse>
    {
        public UpdateOperation(HttpClient httpClient) : base(httpClient) { }
        public override async Task<EmptyResponse> ExecuteRequest((Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{request.orderId}/payments/{request.paymentId}",
                request,
                await ToJson(request.UpdatePaymentRequest)
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage hrm, (Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest) _) =>
        hrm.StatusCode switch
        {
            NoContent => EmptyResponse.Successful(hrm.StatusCode),
            _ => await ToEmptyError(hrm)
        };
    }
}
