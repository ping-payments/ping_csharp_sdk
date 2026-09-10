using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record MerchantPaymentProviderMethodActivationResponse : ApiResponseBase<MerchantPaymentProviderMethodActivation>
    {
        public MerchantPaymentProviderMethodActivationResponse(HttpStatusCode statusCode, bool isSuccessful, ResponseBody<MerchantPaymentProviderMethodActivation>? body, string rawBody) : base(statusCode, isSuccessful, body, rawBody) { }

        public static MerchantPaymentProviderMethodActivationResponse Successful(HttpStatusCode statusCode, MerchantPaymentProviderMethodActivation? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static MerchantPaymentProviderMethodActivationResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator MerchantPaymentProviderMethodActivation?(MerchantPaymentProviderMethodActivationResponse response) => response?.Body?.SuccessfulResponseBody;
    }
}
