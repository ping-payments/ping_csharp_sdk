using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1
{
    public record CreatePaymentConsentResponse : ApiResponseBase<ProviderMethodResponseBody>
    {
        public CreatePaymentConsentResponse(HttpStatusCode statusCode, bool isSuccessful, ResponseBody<ProviderMethodResponseBody>? body, string rawBody) : base(statusCode, isSuccessful, body, rawBody) { }

        public static CreatePaymentConsentResponse Successful(HttpStatusCode statusCode, ProviderMethodResponseBody? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static CreatePaymentConsentResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator SwishRecurringConsentResponseBody?(CreatePaymentConsentResponse response) => response?.Body?.SuccessfulResponseBody as SwishRecurringConsentResponseBody;
        public static implicit operator BankgirotAutogiroConsentResponseBody?(CreatePaymentConsentResponse response) => response?.Body?.SuccessfulResponseBody as BankgirotAutogiroConsentResponseBody;
    }
}
