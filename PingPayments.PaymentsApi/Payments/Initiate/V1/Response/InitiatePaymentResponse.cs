using PingPayments.PaymentsApi.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record InitiatePaymentResponse : ApiResponseBase<InitiatePaymentResponseBody>
    {
        public InitiatePaymentResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<InitiatePaymentResponseBody>? Body) : base(statusCode, IsSuccessful, Body) { }
        public static InitiatePaymentResponse Succesful(HttpStatusCode statusCode, InitiatePaymentResponseBody? b) => new(statusCode, true, b);
        public static InitiatePaymentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e) => new(statusCode, false, e);
    }
}
