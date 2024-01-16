using PingPayments.KYC.Agreement;
using PingPayments.KYC.Merchant;

namespace PingPayments.KYC
{
    public interface IPingKycApiClient
    {
        IMerchantResource Merchant { get; }
        IAgreementResource Agreement { get; }
    }
}