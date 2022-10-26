using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;
using static System.Net.HttpStatusCode;


namespace PingPayments.PaymentsApi.Payments.Reconcile.V1
{
    public class ReconcileOperation : OperationBase<(Guid paymentOrderId, Guid paymentId, OrderItem[] orderItems), EmptyResponse>
    {
        public ReconcileOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid paymentOrderId, Guid paymentId, OrderItem[] orderItems) request) =>
            await BaseExecute
            (
                PUT,
                $"api/v1/payment_orders/{request.paymentOrderId}/payments/{request.paymentId}/funding/reconcile",
                request,
                await ToJson((new { order_items = request.orderItems }))
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage httpResponseMessage, (Guid paymentOrderId, Guid paymentId, OrderItem[] orderItems) _) =>
            httpResponseMessage.StatusCode switch
            {
                NoContent => EmptyResponse.Successful(httpResponseMessage.StatusCode),
                _ => await ToEmptyError(httpResponseMessage)
            };
    }
}
