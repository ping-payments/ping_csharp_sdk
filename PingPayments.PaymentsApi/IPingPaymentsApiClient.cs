using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.Payments;
using PingPayments.PaymentsApi.Payout;

namespace PingPayments.PaymentsApi
{
    public interface IPingPaymentsApiClient
    {
        IMerchantResource Merchants { get; }
        IPaymentOrderResource PaymentOrder { get; }
        IPaymentResource Payments { get; }
        IPingResource Ping { get; }
        IPayoutResource Payouts { get; }
    }
}