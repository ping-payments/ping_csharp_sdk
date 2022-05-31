namespace PingPayments.PaymentsApi.Payments
{
    public class PaymentResource : IPaymentResource
    {
        public PaymentResource(IPaymentsV1 v1) => V1 = v1;
        public IPaymentsV1 V1 { get; }        
    }
}
