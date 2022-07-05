using PingPayments.PaymentLinksApi.Files.Receipt.Get.V1;
using PingPayments.PaymentLinksApi.Files.Shared.V1;


namespace PingPayments.PaymentLinksApi.Files.Receipt
{
    public class ReceiptV1 : IReceiptV1
    {
        public ReceiptV1(Lazy<GetReceiptOperation> getReceiptOperation)
        {
            _getReceiptOperation = getReceiptOperation;
        }

        private readonly Lazy<GetReceiptOperation> _getReceiptOperation;

        public async Task<UrlResponse> Get(Guid paymentLinkID) =>
            await _getReceiptOperation.Value.ExecuteRequest(paymentLinkID);
    }
}

