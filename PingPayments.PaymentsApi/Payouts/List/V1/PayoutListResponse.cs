using PingPayments.PaymentsApi.Payouts.Shared;
using PingPayments.Shared;
using System;
using System.Net;

namespace PingPayments.PaymentsApi.Payouts.List.V1
{
    public record PayoutListResponse : ApiResponseBase<PayoutListResponseBody>
    {
        public PayoutListResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PayoutListResponseBody>? Body, string RawBody) :
            base(StatusCode, IsSuccessful, Body, RawBody)
        { }

        public static PayoutListResponse Successful(HttpStatusCode statusCode, PayoutListResponseBody? b, string rb) => new(statusCode, true, b, rb);
        public static PayoutListResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator PayoutResponseBody[](PayoutListResponse p) =>
            p?.Body?.SuccessfulResponseBody?.Payouts ?? Array.Empty<PayoutResponseBody>();
    }
}
