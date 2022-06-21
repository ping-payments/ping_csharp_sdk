using PingPayments.PaymentsApi.Shared;
using System;
using System.Net;

namespace PingPayments.PaymentsApi.Payout.List.V1
{
    public record PayoutListResponse : ApiResponseBase<PayoutListResponseBody>
    {
        public PayoutListResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<PayoutListResponseBody>? Body, string RawBody) : 
            base(StatusCode, IsSuccessful, Body, RawBody)
        {

        }

        public static implicit operator Payout[](PayoutListResponse p) => 
            p?.Body?.SuccesfulResponseBody?.Payouts ?? Array.Empty<Payout>();
    }
}
