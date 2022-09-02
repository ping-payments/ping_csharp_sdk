using PingPayments.PaymentsApi.Payouts.Shared;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Payouts.Get.V1
{
    public record PayoutGetResponse : ApiResponseBase<PayoutResponseBody>
    {
        public PayoutGetResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PayoutResponseBody>? Body, string RawBody) :
            base(StatusCode, IsSuccessful, Body, RawBody)
        { }

        public static PayoutGetResponse Succesful(HttpStatusCode statusCode, PayoutResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static PayoutGetResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}
