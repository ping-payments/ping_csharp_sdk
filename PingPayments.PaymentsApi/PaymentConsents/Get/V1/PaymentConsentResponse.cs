using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentConsents.Get.V1
{
    public record PaymentConsentResponse : ApiResponseBase<PaymentConsent>
    {
        public PaymentConsentResponse(HttpStatusCode statusCode, bool isSuccessful, ResponseBody<PaymentConsent>? body, string rawBody) : base(statusCode, isSuccessful, body, rawBody) { }
        public static PaymentConsentResponse Successful(HttpStatusCode statusCode, PaymentConsent? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static PaymentConsentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
