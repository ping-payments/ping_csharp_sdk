using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.SigningKeys.Get.V1
{
    public record GetKeyRespons : ApiResponseBase<GetKeyResponseBody>
    {
        public GetKeyRespons(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<GetKeyResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static GetKeyRespons Succesful(HttpStatusCode statusCode, GetKeyResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static GetKeyRespons Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
