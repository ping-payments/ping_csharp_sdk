using PingPayments.KYC.Agreement;
using PingPayments.KYC.Merchant;
using PingPayments.KYC.Session;

namespace PingPayments.KYC
{
    public interface IPingKycApiClient
    {
        ISessionResource Session { get; }
        IMerchantResource Merchant { get; }
        IAgreementResource Agreement { get; }
    }
}