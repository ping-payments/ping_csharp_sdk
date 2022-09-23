using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Merchant.V1.Get.Response
{
    public record GetKycResponse : ApiResponseBase<KycVerificationList>
    {
        public GetKycResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<KycVerificationList> Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static GetKycResponse Succesful(HttpStatusCode statusCode, KycVerificationList b, string rb) => new(statusCode, true, b, rb);
        public static GetKycResponse Failure(HttpStatusCode statusCode, ErrorResponseBody e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator KycVerificationList(GetKycResponse por) =>
          por?.Body?.SuccesfulResponseBody;

        public static implicit operator KycResponseBody[](GetKycResponse por) =>
            (por?.Body?.SuccesfulResponseBody)?.KycVerifications ?? new KycResponseBody[] { };
    }
}
