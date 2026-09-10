namespace PingPayments.Mimic.PaymentConsent
{
    public class PaymentConsentResource : IPaymentConsentResource
    {
        public PaymentConsentResource(PaymentConsentV1 v1) => V1 = v1;
        public IPaymentConsentV1 V1 { get; }
    }
}
