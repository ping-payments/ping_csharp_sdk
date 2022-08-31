namespace PingPayments.PaymentLinksApi.Files.Receipt
{
    public class ReceiptResource : IReceiptResource
    {
        public ReceiptResource(IReceiptV1 v1)
        {
            V1 = v1;
        }

        public IReceiptV1 V1 { get; }
    }
}
