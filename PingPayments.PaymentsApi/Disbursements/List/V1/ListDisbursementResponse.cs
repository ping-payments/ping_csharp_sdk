using PingPayments.PaymentsApi.Disbursements.Shared;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Disbursements.List.V1
{
    public record ListDisbursementResponse : ApiResponseBase<DisbursementList>
    {
        public ListDisbursementResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<DisbursementList>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static ListDisbursementResponse Succesful(HttpStatusCode statusCode, DisbursementList? body, string rawBody) => new(statusCode, true, body, rawBody);
        public static ListDisbursementResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator DisbursementList?(ListDisbursementResponse disbursementResponse) =>
            disbursementResponse?.Body?.SuccesfulResponseBody;

        public static implicit operator Disbursement[](ListDisbursementResponse disbursementResponse) =>
            (disbursementResponse?.Body?.SuccesfulResponseBody)?.Disbursements ?? new Disbursement[] { };
    }
}
