using PingPayments.PaymentLinksApi.Files.Shared.V1;

namespace PingPayments.PaymentLinksApi.Files.Receipt
{
    public interface IReceiptV1
    {
        Task<UrlResponse> Get(Guid paymentLinkID);
    }
}