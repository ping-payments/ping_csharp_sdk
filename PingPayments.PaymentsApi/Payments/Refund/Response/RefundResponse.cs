using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record RefundResponse : ApiResponseBase<RefundResponseBody>
    {
        public RefundResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<RefundResponseBody>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static RefundResponse Successful(HttpStatusCode statusCode, RefundResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static RefundResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
