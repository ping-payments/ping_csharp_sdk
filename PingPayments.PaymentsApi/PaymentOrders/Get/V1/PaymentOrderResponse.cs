using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentOrders.Get.V1
{
    public record PaymentOrderResponse : ApiResponseBase<PaymentOrder>
    {
        public PaymentOrderResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentOrder>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentOrderResponse Succesful(HttpStatusCode statusCode, PaymentOrder? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentOrderResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
