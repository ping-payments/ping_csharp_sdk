using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1
{
    public record GetSessionResponse : ApiResponseBase<GetSessionResponseBody>
    {
        public GetSessionResponse(HttpStatusCode statusCode, bool IsSuccessful, ResponseBody<GetSessionResponseBody> body, string rawBody) : base(statusCode, IsSuccessful, body, rawBody) { }
        public static GetSessionResponse Successful(HttpStatusCode statusCode, GetSessionResponseBody body, string rawBody) => new(statusCode, true, body, rawBody);
        public static GetSessionResponse Failure(HttpStatusCode statusCode, ErrorResponseBody error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
