﻿using PingPayments.KYC.Merchant.V1.Shared;
using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Merchant.V1.Get.Response
{
    public record GetKycResponse : ApiResponseBase<KycVerificationList>
    {
        public GetKycResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<KycVerificationList> body, string rawBody) : base(StatusCode, IsSuccessful, body, rawBody) { }
        public static GetKycResponse Successful(HttpStatusCode statusCode, KycVerificationList body, string rawBody) => new(statusCode, true, body, rawBody);
        public static GetKycResponse Failure(HttpStatusCode statusCode, ErrorResponseBody error, string rawBody) => new(statusCode, false, error, rawBody);

        public static implicit operator KycVerificationList(GetKycResponse getKycResponse) =>
          getKycResponse?.Body?.SuccessfulResponseBody;

        public static implicit operator KycBody[](GetKycResponse getKycResponse) =>
            (getKycResponse?.Body?.SuccessfulResponseBody)?.KycVerifications ?? new KycBody[] { };
    }
}
