using PingPayments.Mimic.Deposit;
using PingPayments.Mimic.Merchants;

namespace PingPayments.Mimic
{
    public interface IPingMimicApiClient
    {
        IDepositResource Deposit { get; }
        IMerchantResource Merchant { get; }
    }
}