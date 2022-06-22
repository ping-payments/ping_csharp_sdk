using System.Net;

namespace PingPayments.PaymentsApi.Shared
{
    public record EmptyResponse : ApiResponseBase<EmptySuccesfulResponseBody>
    {
        public EmptyResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<EmptySuccesfulResponseBody>? Body, string RawBody)  : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static EmptyResponse Empty(HttpStatusCode statusCode, bool isSuccessful) => new(statusCode, isSuccessful, EmptySuccesfulResponseBody.Empty, string.Empty);
        public static EmptyResponse Succesful(HttpStatusCode statusCode) => Empty(statusCode, true);
        public static EmptyResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
