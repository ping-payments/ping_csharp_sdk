using PingPayments.PaymentLinksApi.Ping;
using PingPayments.PaymentLinksApi.Ping.V1;
using PingPayments.PaymentLinksApi.PaymentLinks;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Cancel.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1;
using PingPayments.PaymentLinksApi.Files.Invoice;
using PingPayments.PaymentLinksApi.Files.Invoice.Create.V1;
using PingPayments.PaymentLinksApi.Files.Invoice.Get.V1;
using PingPayments.PaymentLinksApi.Files.Receipt;
using PingPayments.PaymentLinksApi.Files.Receipt.Get.V1;

namespace PingPayments.PaymentLinksApi
{
    public class PingPaymentLinksApiClient : IPingPaymentLinksApiClient
    {
        public PingPaymentLinksApiClient(HttpClient httpClient)
        {
            var pingV1 = new PingV1
            (
                new Lazy<PingOperation>(() => new PingOperation(httpClient))
            );
            _ping = new Lazy<IPingResource>(() => new PingResource(pingV1));


            var paymentLinksV1 = new PaymentLinksV1
            (
                new Lazy<ListPaymentLinksOperation>(() => new ListPaymentLinksOperation(httpClient)),
                new Lazy<CreatePaymentLinkOperation>(() => new CreatePaymentLinkOperation(httpClient)),
                new Lazy<GetPaymentLinkOperation>(()=> new GetPaymentLinkOperation(httpClient)),
                new Lazy<CancelPaymentLinkOperation>(()=> new CancelPaymentLinkOperation(httpClient)),
                new Lazy<SendPaymentLinkOperation>(()=> new SendPaymentLinkOperation(httpClient))
            );
            _paymentLinks = new Lazy<IPaymentLinksResource>(() => new PaymentLinkResource(paymentLinksV1));

            var invoiceV1 = new InvoiceV1
            (
                new Lazy<CreateInvoiceOperation>(() => new CreateInvoiceOperation(httpClient)),
                new Lazy<GetInvoiceOperation>(() => new GetInvoiceOperation(httpClient))
            );
            _invoice = new Lazy<IInvoiceResource>(() => new InvoiceResource(invoiceV1));

            var receiptV1 = new ReceiptV1
           (
               new Lazy<GetReceiptOperation>(() => new GetReceiptOperation(httpClient))
           );
            _receipt = new Lazy<IReceiptResource>(() => new ReceiptResource(receiptV1));
        }

        private readonly Lazy<IPingResource> _ping;
        public IPingResource Ping => _ping.Value;

        private readonly Lazy<IPaymentLinksResource> _paymentLinks;
        public IPaymentLinksResource PaymentLinks => _paymentLinks.Value;

        private readonly Lazy<IInvoiceResource> _invoice;
        public IInvoiceResource Invoice => _invoice.Value;

        private readonly Lazy<IReceiptResource> _receipt;
        public IReceiptResource Receipt => _receipt.Value;
    }
}