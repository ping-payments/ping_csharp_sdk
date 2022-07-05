namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public class PaymentLinkResource : IPaymentLinksResource
    {
        public PaymentLinkResource(IPaymentLinksV1 v1)
        {
            V1 = v1;
        }

        public IPaymentLinksV1 V1 { get; }
    }
}
