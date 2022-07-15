using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record PaymentResponse : ApiResponseBase<PaymentResponseBody>
    {
        public PaymentResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentResponse Succesful(HttpStatusCode statusCode, PaymentResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static PaymentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
