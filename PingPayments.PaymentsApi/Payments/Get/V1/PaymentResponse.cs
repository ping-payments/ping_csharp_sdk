using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record PaymentResponse : ApiResponseBase<Payment>
    {
        public PaymentResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Payment>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentResponse Successful(HttpStatusCode statusCode, Payment? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
