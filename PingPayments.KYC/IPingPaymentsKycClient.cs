using PingPayments.KYC.Merchant;
using PingPayments.KYC.Session;

namespace PingPayments.KYC
{
    public interface IPingPaymentsKycClient
    {
        ISessionResource Session { get; }
        IMerchantResource Merchant { get; }
    }
}