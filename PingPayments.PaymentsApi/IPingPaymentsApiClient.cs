using PingPayments.PaymentsApi.Allocations;
using PingPayments.PaymentsApi.DepositBankAccount;
using PingPayments.PaymentsApi.Disbursements;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession;
using PingPayments.PaymentsApi.LiquidityAccounts;
using PingPayments.PaymentsApi.Merchants;
using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payouts;
using PingPayments.PaymentsApi.Ping;
using PingPayments.PaymentsApi.Poke;
using PingPayments.PaymentsApi.SigningKeys;
using PingPayments.PaymentsApi.Tenants;

namespace PingPayments.PaymentsApi
{
    public interface IPingPaymentsApiClient
    {
        IAllocationResource Allocation { get; }
        IDisbursementResource Disbursements { get; }
        IDepositBankAccountResource DepositBankAccount { get; }
        IAccountVerificationSessionResource AccountVerification { get; }
        IMerchantResource Merchants { get; }
        ILiquidityAccountResource LiquidityAccounts { get; }
        IPaymentOrderResource PaymentOrder { get; }
        IPaymentResource Payments { get; }
        IPingResource Ping { get; }
        IPayoutResource Payouts { get; }
        ITenantResource Tenants { get; }
        IPokeResource Poke { get; }
        ISigningKeyResource SigningKey { get; }
    }
}