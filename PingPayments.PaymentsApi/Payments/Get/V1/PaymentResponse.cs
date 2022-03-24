using PingPayments.PaymentsApi.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record PaymentResponse : ApiResponseBase<PaymentResponseBody>
    {
        public PaymentResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PaymentResponseBody>? Body) : base(StatusCode, IsSuccessful, Body) { }
        public static PaymentResponse Succesful(HttpStatusCode statusCode, PaymentResponseBody? b) => new(statusCode, true, b);
        public static PaymentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e) => new(statusCode, false, e);
    }
}
