namespace PingPayments.PaymentsApi.Payments
{
    public class PaymentEndpoints : IPaymentEndpoints
    {
        public PaymentEndpoints(IPaymentsV1 v1) => V1 = v1;
        public IPaymentsV1 V1 { get; }        
    }
}
