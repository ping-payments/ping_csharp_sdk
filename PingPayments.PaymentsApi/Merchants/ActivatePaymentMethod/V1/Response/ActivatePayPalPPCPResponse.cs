using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record ActivatePayPalPPCPResponse : ApiResponseBase<ActivatePayPalPPCPResponseBody>
    {
        public ActivatePayPalPPCPResponse(HttpStatusCode statusCode, bool isSuccessful, ResponseBody<ActivatePayPalPPCPResponseBody>? body, string rawBody) : base(statusCode, isSuccessful, body, rawBody) { }

        public static ActivatePayPalPPCPResponse Successful(HttpStatusCode statusCode, ActivatePayPalPPCPResponseBody? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ActivatePayPalPPCPResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator ActivatePayPalPPCPResponseBody?(ActivatePayPalPPCPResponse response) => response?.Body?.SuccessfulResponseBody;
    }
}
