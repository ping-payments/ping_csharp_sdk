using PingPayments.KYC.Merchant.V1.Shared;
using PingPayments.Shared;

namespace PingPayments.KYC.Merchant.V1.Get
{
    public record KycVerificationList(KycBody[] KycVerifications) : EmptySuccessfulResponseBody { }
}
