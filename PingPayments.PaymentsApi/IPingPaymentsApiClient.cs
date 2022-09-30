using PingPayments.PaymentsApi.Disbursements;
using PingPayments.PaymentsApi.Merchants;
using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payouts;
using PingPayments.PaymentsApi.Ping;
using PingPayments.PaymentsApi.Poke;
using PingPayments.PaymentsApi.Tenants;
using PingPayments.PaymentsApi.SigningKeys;

namespace PingPayments.PaymentsApi
{
    public interface IPingPaymentsApiClient
    {
        IDisbursementResource Disbursements { get; }
        IMerchantResource Merchants { get; }
        IPaymentOrderResource PaymentOrder { get; }
        IPaymentResource Payments { get; }
        IPingResource Ping { get; }
        IPayoutResource Payouts { get; }
        ITenantResource Tenants { get; }
        IPokeResource Poke { get; }
        ISigningKeyResource SigningKey { get; }
    }
}