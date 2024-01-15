using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1
{
    public record CreateSessionResponse : ApiResponseBase<CreateSessionResponseBody>
    {
        public CreateSessionResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<CreateSessionResponseBody> body, string rawBody) : base(statusCode, IsSuccessful, body, rawBody) { }
        public static CreateSessionResponse Successful(HttpStatusCode statusCode, CreateSessionResponseBody body, string rawBody) => new(statusCode, true, body, rawBody);
        public static CreateSessionResponse Failure(HttpStatusCode statusCode, ErrorResponseBody error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
