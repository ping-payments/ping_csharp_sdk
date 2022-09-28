using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.SigningKeys.Generate.V1
{
    public record GenerateResponse : ApiResponseBase<GenerateKeyResponseBody>
    {
        public GenerateResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GenerateKeyResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static GenerateResponse Succesful(HttpStatusCode statusCode, GenerateKeyResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static GenerateResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
