namespace PingPayments.PaymentsApi.PaymentConsents
{
    public class PaymentConsentResource : IPaymentConsentResource
    {
        public PaymentConsentResource(IPaymentConsentV1 v1) => V1 = v1;
        public IPaymentConsentV1 V1 { get; }
    }
}
