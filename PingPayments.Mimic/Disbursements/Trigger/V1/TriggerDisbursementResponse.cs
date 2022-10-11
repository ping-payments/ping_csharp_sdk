using PingPayments.Shared;
using System.Net;

namespace PingPayments.Mimic.Disbursements.Trigger.V1
{
    public record TriggerDisbursementResponse : ApiResponseBase<TriggerDisbursementResponseBody>
    {
        public TriggerDisbursementResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<TriggerDisbursementResponseBody> Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static TriggerDisbursementResponse Succesful(HttpStatusCode statusCode, TriggerDisbursementResponseBody body, string rawBody) => new(statusCode, true, body, rawBody);
        public static TriggerDisbursementResponse Failure(HttpStatusCode statusCode, ErrorResponseBody error, string rawBody) => new(statusCode, false, error, rawBody);
    }
}
