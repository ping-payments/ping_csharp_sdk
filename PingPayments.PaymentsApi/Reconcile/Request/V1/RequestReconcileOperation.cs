using System;
using System.Net.Http;
using System.Threading.Tasks;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared;
using static System.Net.HttpStatusCode;
using static PingPayments.Shared.Enums.HttpRequestTypeEnum;


namespace PingPayments.PaymentsApi.Reconcile.Request.V1
{
    public class RequestReconcileOperation : OperationBase<(Guid paymentId, Guid paymentOrderId, OrderItem[] orderItems), EmptyResponse>
    {
        public RequestReconcileOperation(HttpClient httpClient) : base(httpClient) { }

        public override async Task<EmptyResponse> ExecuteRequest((Guid paymentId, Guid paymentOrderId, OrderItem[] orderItems) request) =>
            await BaseExecute
            (
                PUT,
                $"/api/v1/payment_orders/{request.paymentOrderId}/payments/{request.paymentId}/funding/reconcile",
                request,
                await ToJson((new { order_items = request.orderItems }))
            );

        protected override async Task<EmptyResponse> ParseHttpResponse(HttpResponseMessage httpResponseMessage, (Guid paymentId, Guid paymentOrderId, OrderItem[] orderItems) _) =>
            httpResponseMessage.StatusCode switch
            {
                OK => EmptyResponse.Successful(httpResponseMessage.StatusCode),
                _ => await ToEmptyError(httpResponseMessage)
            };
    }
}
