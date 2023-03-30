using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Shared
{
    public record PaymentLinksTextResponse : PaymentLinksApiResponseBase<TextResponseBody>
    {
        public PaymentLinksTextResponse(HttpStatusCode StatusCode, bool IsSuccessful, PaymentLinksResponseBody<TextResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static PaymentLinksTextResponse Successful(HttpStatusCode statusCode, string text, string rb) => new(statusCode, true, new TextResponseBody(text), rb);
        public static PaymentLinksTextResponse Failure(HttpStatusCode statusCode, PaymentLinksErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
