using PingPayments.PaymentsApi.Disbursements.Shared;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Disbursements.Get.V1
{
    public record GetDisbursementResponse : ApiResponseBase<Disbursement>
    {
        public GetDisbursementResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Disbursement>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static GetDisbursementResponse Succesful(HttpStatusCode statusCode, Disbursement? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static GetDisbursementResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
