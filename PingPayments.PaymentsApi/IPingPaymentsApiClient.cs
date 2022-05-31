using PingPayments.PaymentsApi.PaymentOrders;
using PingPayments.PaymentsApi.Payments;

namespace PingPayments.PaymentsApi
{
    public interface IPingPaymentsApiClient
    {
        IMerchantResource Merchants { get; }
        IPaymentOrderResource PaymentOrder { get; }
        IPaymentResource Payments { get; }
    }
}