using PingPayments.PaymentLinksApi.Shared;
using PingPayments.PaymentLinksApi.Files.Invoice.Get.V1;
using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;

namespace PingPayments.PaymentLinksApi.Files.Invoice
{
    public interface IInvoiceV1
    {
        Task<EmptyResponse> Create(CreateInvoiceRequest createInvoiceRequest);
        Task<InvoiceResponse> Get(Guid paymentLinkID);
    }
}