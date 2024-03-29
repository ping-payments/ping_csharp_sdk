﻿using PingPayments.Shared;
using System.Net;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public record MerchantResponse : ApiResponseBase<Merchant>
    {
        public MerchantResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<Merchant>? Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }

        public static implicit operator Merchant?(MerchantResponse merchantResponse) =>
            merchantResponse.IsSuccessful &&
            merchantResponse.Body?.SuccessfulResponseBody != null ?
                merchantResponse.Body.SuccessfulResponseBody :
                null;
        public static MerchantResponse Successful(HttpStatusCode statusCode, Merchant? b, string rb) => new(statusCode, true, b, rb);
        public static MerchantResponse Failure(HttpStatusCode statusCode, ErrorResponseBody? e, string rb) => new(statusCode, false, e, rb);

    }
}