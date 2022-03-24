namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class PaymentOrderEndpoints : IPaymentOrderEndpoints
    {
        public PaymentOrderEndpoints(IPaymentOrderV1 v1) => V1 = v1;
        public IPaymentOrderV1 V1 { get; }
    }
}
