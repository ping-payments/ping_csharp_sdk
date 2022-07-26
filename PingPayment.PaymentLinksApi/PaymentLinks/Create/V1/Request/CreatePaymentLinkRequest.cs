using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.Shared.Enums;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record CreatePaymentLinkRequest : PaymentLink
    {
        public CreatePaymentLinkRequest
        (
            Guid paymentOrderId,
            CurrencyEnum currency,
            Customer customer,
            string dueDate,
            string local,
            IEnumerable<Item> items,
            Supplier supplier,
            IEnumerable<PaymentProviderMethod> paymentProviderMethods,
            string? checkoutCancelUrl = null,
            string? checkoutSuccessUrl = null,
            string? checkoutUrl = null,
            Adress? deliveryAdress = null,
            Adress? invoiceAdress = null,
            string? logoImageLink = null,
            string? paymentLinkStatusCallbackUrl = null,
            IDictionary<string, dynamic>? metadata = null
        )
        {
            PaymentOrderId = paymentOrderId;
            Currency = currency;
            Customer = customer;
            DueDate = dueDate;
            Local = local;
            Items = items;
            Supplier = supplier;
            TotalAmount = items.TotalAmountMinorCurrencyUnit();
            PaymentProviderMethods = paymentProviderMethods;
            CheckoutCancelUrl = checkoutCancelUrl;
            CheckoutSuccessUrl = checkoutSuccessUrl;
            CheckoutUrl = checkoutUrl;
            DeliveryAdress = deliveryAdress;
            InvoiceAdress = invoiceAdress;
            LogoImageLink = logoImageLink;
            PaymentLinkStatusCallbackUrl = paymentLinkStatusCallbackUrl;
            Metadata = metadata ?? new Dictionary<string, dynamic>();
        }

        public CreatePaymentLinkRequest AndCheckoutCancelUrl(string checkoutCancelUrl)
        {
            CheckoutCancelUrl = checkoutCancelUrl;
            return this;
        }
        public CreatePaymentLinkRequest AndCheckoutSuccessUrl(string checkoutSuccessUrl)
        {
            CheckoutSuccessUrl = checkoutSuccessUrl;
            return this;
        }
        public CreatePaymentLinkRequest AddCheckoutUrl(string checkoutUrl)
        {
            CheckoutUrl = checkoutUrl;
            return this;
        }

        public CreatePaymentLinkRequest AddDeliveryAdress(string city, string streetAdress, string zip)
        {
            Adress _adress = new(city, streetAdress, zip);
            DeliveryAdress = _adress;
            return this;
        }
        public CreatePaymentLinkRequest AddInvoiceAdress(string city, string streetAdress, string zip)
        {
            Adress _adress = new(city, streetAdress, zip);
            InvoiceAdress = _adress;
            return this;
        }
        public CreatePaymentLinkRequest AddLogoImageLink(string logoImageLink)
        {
            LogoImageLink = logoImageLink;
            return this;
        }
        public CreatePaymentLinkRequest AddPaymentLinkStatusCallbackUrl(string paymentLinkStatusCallbackUrl)
        {
            PaymentLinkStatusCallbackUrl = paymentLinkStatusCallbackUrl;
            return this;
        }
        public CreatePaymentLinkRequest AddMetadata(Dictionary<string, dynamic> metadata)
        {
            Metadata = metadata;
            return this;
        }
    }
}
