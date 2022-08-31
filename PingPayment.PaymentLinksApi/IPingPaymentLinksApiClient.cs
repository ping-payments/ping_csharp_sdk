using PingPayments.PaymentLinksApi.Files.Invoice;
using PingPayments.PaymentLinksApi.Files.Receipt;
using PingPayments.PaymentLinksApi.PaymentLinks;
using PingPayments.PaymentLinksApi.Ping;

namespace PingPayments.PaymentLinksApi
{
    public interface IPingPaymentLinksApiClient
    {
        IPingResource Ping { get; }

        IPaymentLinksResource PaymentLinks { get;  }

        IInvoiceResource Invoice { get; }

        IReceiptResource Receipt { get; }
    }
}
