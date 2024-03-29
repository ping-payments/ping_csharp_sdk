﻿using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public record MerchantsResponse : ApiResponseBase<Merchant[]>
    {
        public MerchantsResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Merchant[]>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static implicit operator Merchant[]?(MerchantsResponse merchantResponse) =>
            merchantResponse.IsSuccessful && merchantResponse.Body?.SuccessfulResponseBody != null 
                ? merchantResponse.Body.SuccessfulResponseBody 
                : null;

        public static MerchantsResponse Successful(HttpStatusCode statusCode, Merchant[]? b, string rb) => new(statusCode, true, b, rb);
        public static MerchantsResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);
    }
}