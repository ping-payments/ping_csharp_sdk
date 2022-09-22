using PingPayments.Shared;
using System.Net;

namespace PingPayments.KYC.Merchant.V1.Get.Response
{
    public record GetMerchantKycResponse : ApiResponseBase<MerchantKycVerificationList>
    {
        public GetMerchantKycResponse(HttpStatusCode StatusCode, bool IsSuccessful, ResponseBody<MerchantKycVerificationList> Body, string RawBody) : base(StatusCode, IsSuccessful, Body, RawBody) { }
        public static GetMerchantKycResponse Succesful(HttpStatusCode statusCode, MerchantKycVerificationList b, string rb) => new(statusCode, true, b, rb);
        public static GetMerchantKycResponse Failure(HttpStatusCode statusCode, ErrorResponseBody e, string rb) => new(statusCode, false, e, rb);

        public static implicit operator MerchantKycVerificationList(GetMerchantKycResponse por) =>
          por?.Body?.SuccesfulResponseBody;

        public static implicit operator GetMerchantKycResponseBody[](GetMerchantKycResponse por) =>
            (por?.Body?.SuccesfulResponseBody)?.listOperationResponseBody ?? new GetMerchantKycResponseBody[] { };
    }
}
