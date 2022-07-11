using System.Net;

namespace PingPayments.PaymentLinksApi.Shared
{
    public record TextResponse : ApiResponseBase<TextResponseBody>
    {
        public TextResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<TextResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static TextResponse Succesful(HttpStatusCode statusCode, string text, string rb) => new(statusCode, true, new TextResponseBody(text), rb);
        public static TextResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
