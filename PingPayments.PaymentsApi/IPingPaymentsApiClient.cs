using PingPayments.PaymentsApi.Merchants;
using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payouts;
using PingPayments.PaymentsApi.Ping;
using PingPayments.PaymentsApi.SigningKeys;


namespace PingPayments.PaymentsApi
{
    public interface IPingPaymentsApiClient
    {
        IMerchantResource Merchants { get; }
        IPaymentOrderResource PaymentOrder { get; }
        IPaymentResource Payments { get; }
        IPingResource Ping { get; }
        IPayoutResource Payouts { get; }
        ISigningKeyResource SigningKey { get; }
    }
}