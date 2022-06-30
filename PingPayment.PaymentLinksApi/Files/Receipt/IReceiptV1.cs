using PingPayments.PaymentLinksApi.Files.Receipt.Get.V1;

namespace PingPayments.PaymentLinksApi.Files.Receipt
{
    public interface IReceiptV1
    {
        Task<InvoiceResponse> Get(Guid paymentLinkID);
    }
}