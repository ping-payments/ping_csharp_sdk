using PingPayments.Mimic.Autogiro;
using PingPayments.Mimic.Deposit;
using PingPayments.Mimic.Disbursements;
using PingPayments.Mimic.Merchants;
using PingPayments.Mimic.PaymentConsent;

namespace PingPayments.Mimic
{
    public interface IPingMimicApiClient
    {
        IDepositResource Deposit { get; }
        IMerchantResource Merchant { get; }
        IDisbursementResource Disbursement { get; }
        IAutogiroResource Autogiro { get; }
        IPaymentConsentResource PaymentConsent { get; }
    }
}
