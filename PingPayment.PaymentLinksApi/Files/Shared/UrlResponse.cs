using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentLinksApi.Files.Shared.V1
{
    public record UrlResponse : ApiResponseBase<UrlResponseBody>
    {
        public UrlResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<UrlResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static UrlResponse Successful(HttpStatusCode statusCode, UrlResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static UrlResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
