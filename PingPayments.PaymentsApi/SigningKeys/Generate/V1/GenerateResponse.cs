using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.SigningKeys.Generate.V1
{
    public record GenerateResponse : ApiResponseBase<GenerateKeyResponseBody>
    {
        public GenerateResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenerateKeyResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static GenerateResponse Successful(HttpStatusCode statusCode, GenerateKeyResponseBody? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static GenerateResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
