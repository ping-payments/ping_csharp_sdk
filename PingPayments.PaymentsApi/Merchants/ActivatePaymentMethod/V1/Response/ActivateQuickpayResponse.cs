using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record ActivateQuickpayResponse : ApiResponseBase<ActivateQuickpayResponseBody>
    {
        public ActivateQuickpayResponse(HttpStatusCode statusCode, bool isSuccessful, ResponseBody<ActivateQuickpayResponseBody>? body, string rawBody) : base(statusCode, isSuccessful, body, rawBody) { }

        public static ActivateQuickpayResponse Successful(HttpStatusCode statusCode, ActivateQuickpayResponseBody? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ActivateQuickpayResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator ActivateQuickpayResponseBody?(ActivateQuickpayResponse response) => response?.Body?.SuccessfulResponseBody;
    }
}
