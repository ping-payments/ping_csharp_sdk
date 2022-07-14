using PingPayments.PaymentLinksApi.Shared;
using PingPayments.PaymentLinksApi.Files.Invoice.Get.V1;
using PingPayments.PaymentLinksApi.Files.Shared.V1;
using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;
using PingPayments.Shared;

namespace PingPayments.PaymentLinksApi.Files.Invoice
{
    public class InvoiceV1 : IInvoiceV1
    {
        public InvoiceV1(Lazy<CreateInvoiceOperation> createPaymentLinkOperation, Lazy<GetInvoiceOperation> getInvoiceOperation)
        {
            _createInvoiceOperation = createPaymentLinkOperation;
            _getInvoiceOperation = getInvoiceOperation;
        }

        private readonly Lazy<CreateInvoiceOperation> _createInvoiceOperation;
        private readonly Lazy<GetInvoiceOperation> _getInvoiceOperation;

        public async Task<EmptyResponse> Create(Guid paymentLinkID, CreateInvoiceRequest createInvoiceRequest) =>
            await _createInvoiceOperation.Value.ExecuteRequest((paymentLinkID,  createInvoiceRequest));

        public async Task<UrlResponse> Get(Guid paymentLinkID) =>
            await _getInvoiceOperation.Value.ExecuteRequest(paymentLinkID);
    } 
}