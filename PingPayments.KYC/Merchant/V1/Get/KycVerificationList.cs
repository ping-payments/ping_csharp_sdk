using PingPayments.KYC.Merchant.V1.Get.Response;
using PingPayments.Shared;

namespace PingPayments.KYC.Merchant.V1.Get
{
    public record KycVerificationList(KycResponseBody[] KycVerifications) : EmptySuccessfulResponseBody { }
}
