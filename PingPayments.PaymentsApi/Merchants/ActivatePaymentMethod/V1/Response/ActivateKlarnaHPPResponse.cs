using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record ActivateKlarnaHPPResponse : ApiResponseBase<ActivateKlarnaHPPResponseBody>
    {
        public ActivateKlarnaHPPResponse(HttpStatusCode statusCode, bool isSuccessful, ResponseBody<ActivateKlarnaHPPResponseBody>? body, string rawBody) : base(statusCode, isSuccessful, body, rawBody) { }

        public static ActivateKlarnaHPPResponse Successful(HttpStatusCode statusCode, ActivateKlarnaHPPResponseBody? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ActivateKlarnaHPPResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator ActivateKlarnaHPPResponseBody?(ActivateKlarnaHPPResponse response) => response?.Body?.SuccessfulResponseBody;
    }
}
