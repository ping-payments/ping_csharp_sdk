using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Session.V1.Initiate.Response
{
    public record InitiateSessionResponse : ApiResponseBase<InitiateSessionResponseBody>
    {
        public InitiateSessionResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<InitiateSessionResponseBody> body, string rawBody) : base(statusCode, IsSuccessful, body, rawBody) { }
        public static InitiateSessionResponse Succesful(HttpStatusCode statusCode, InitiateSessionResponseBody body, string rawBody) => new(statusCode, true, body, rawBody);
        public static InitiateSessionResponse Failure(HttpStatusCode statusCode, ErrorResponseBody error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
