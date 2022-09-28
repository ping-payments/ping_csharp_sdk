using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.SigningKeys.Get.V1
{
    public record GetKeyRespons : ApiResponseBase<GetKeyResponseBody>
    {
        public GetKeyRespons(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GetKeyResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static GetKeyRespons Succesful(HttpStatusCode statusCode, GetKeyResponseBody? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static GetKeyRespons Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
