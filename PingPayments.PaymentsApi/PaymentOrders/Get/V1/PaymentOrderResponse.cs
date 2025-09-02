using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public record PaymentOrderResponse : ApiResponseBase<PaymentOrderExtended>
    {
        public PaymentOrderResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentOrderExtended>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentOrderResponse Successful(HttpStatusCode statusCode, PaymentOrderExtended? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentOrderResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator PaymentOrderExtended(PaymentOrderResponse por) =>
            (por?.Body?.SuccessfulResponseBody) ?? new PaymentOrderExtended { };
    }
}
