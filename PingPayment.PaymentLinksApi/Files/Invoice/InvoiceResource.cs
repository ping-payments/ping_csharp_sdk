namespace PingPayments.PaymentLinksApi.Files.Invoice
{
    public class InvoiceResource : IInvoiceResource
    {
        public InvoiceResource(IInvoiceV1 v1)
        {
            V1 = v1;
        }

        public IInvoiceV1 V1 { get; }
    }
}
