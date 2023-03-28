using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;
using PingPayments.PaymentLinksApi.Files.Shared.V1;
using PingPayments.PaymentLinksApi.Shared;

namespace PingPayments.PaymentLinksApi.Files.Invoice
{
    public interface IInvoiceV1
    {
        Task<PaymentLinksEmptyResponse> Create(Guid paymentLinkID, CreateInvoiceRequest createInvoiceRequest);
        Task<GetInvoiceResponse> Get(Guid paymentLinkID);
    }
}