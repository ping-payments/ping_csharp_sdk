namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class PaymentOrderResource : IPaymentOrderResource
    {
        public PaymentOrderResource(IPaymentOrderV1 v1) => V1 = v1;
        public IPaymentOrderV1 V1 { get; }
    }
}
