using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Session.V1.Initiate.Response
{
    public record InitiateSessionResponse : ApiResponseBase<InitiateSessionResponseBody>
    {
        public InitiateSessionResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<InitiateSessionResponseBody> Body, string RawBody) : base(statusCode, IsSuccessful, Body, RawBody) { }
        public static InitiateSessionResponse Succesful(HttpStatusCode statusCode, InitiateSessionResponseBody b, string rb) => new(statusCode, true, b, rb);
        public static InitiateSessionResponse Failure(HttpStatusCode statusCode, ErrorResponseBody e, string rb) => new(statusCode, false, e, rb);
    }
}
