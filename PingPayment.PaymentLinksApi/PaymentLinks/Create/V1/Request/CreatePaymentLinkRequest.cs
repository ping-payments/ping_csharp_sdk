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
    }
}
