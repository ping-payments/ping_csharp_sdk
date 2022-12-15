using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record CreatePaymentLinkRequest : PaymentLink
    {
        public CreatePaymentLinkRequest
        (
            Guid paymentOrderId,
            CurrencyEnum currency,
            Customer customer,
            string local,
            IEnumerable<Item> items,
            Supplier supplier,
            IEnumerable<PaymentProviderMethod>? paymentProviderMethods,
            string? dueDate = null,
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

        /// <summary>
        /// Customer gets redirected here when canceling a checkout
        /// </summary>
        [JsonPropertyName("checkout_cancel_url")]
        public string? CheckoutCancelUrl { get; set; }

        /// <summary>
        /// Customer gets redirected here when completed a checkout successfully
        /// </summary>
        [JsonPropertyName("checkout_success_url")]
        public string? CheckoutSuccessUrl { get; set; }

        /// <summary>
        /// The currencies which the amounts is given in
        /// </summary>
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }

        /// <summary>
        /// Supplier of a PaymentLink 
        /// </summary>
        [JsonPropertyName("supplier")]
        public Supplier Supplier { get; set; }
    }
}
