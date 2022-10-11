using System.Net;

namespace PingPayments.Shared
{
    public record EmptyResponse : ApiResponseBase<EmptySuccessfulResponseBody>
    {
        public EmptyResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<EmptySuccessfulResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static EmptyResponse Empty(HttpStatusCode statusCode, bool isSuccessful) => new(statusCode, isSuccessful, EmptySuccessfulResponseBody.Empty, string.Empty);
        public static EmptyResponse Successful(HttpStatusCode statusCode) => Empty(statusCode, true);
        public static EmptyResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
