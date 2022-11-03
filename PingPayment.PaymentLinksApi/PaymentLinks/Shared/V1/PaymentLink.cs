using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record PaymentLink : EmptySuccessfulResponseBody
    {
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
        /// The url to the checkout (should only be set if building a custom checkout)
        /// </summary>
        [JsonPropertyName("checkout_url")]
        public string? CheckoutUrl { get; set; }

        /// <summary>
        /// The currencies which the amounts is given in
        /// </summary>
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }


        /// <summary>
        /// Customer intended to pay the PaymentLink 
        /// </summary>
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Adress for delivery 
        /// </summary>
        [JsonPropertyName("delivery_address")]
        public Adress? DeliveryAdress { get; set; }

        /// <summary>
        ///  The expiration date of the PaymentLink 
        /// </summary>
        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        ///  Invoice adress for the payment  
        /// </summary>
        [JsonPropertyName("invoice_address")]
        public Adress? InvoiceAdress { get; set; }

        /// <summary>
        ///  Items iclueded in the PaymentLink 
        /// </summary>
        [JsonPropertyName("items")]
        public IEnumerable<Item> Items { get; set; }

        /// <summary>
        /// The language used for the invoice. This will determin the language on the receipt/invoice and in the checkout
        /// </summary>
        [JsonPropertyName("locale")]
        public string Local { get; set; }

        /// <summary>
        /// An url to a png image to view on the invoice and receipt. The image dimensions shouls be aproxomatly 3:1 for the best fit.
        /// </summary>
        [JsonPropertyName("logo_image_link")]
        public string? LogoImageLink { get; set; }

        /// <summary>
        /// Custom metadata for a PaymentLink 
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic>? Metadata { get; set; }


        /// <summary>
        /// Callback url for checking the status of a PaymentLink  
        /// </summary>
        [JsonPropertyName("payment_link_status_callback_url")]
        public string? PaymentLinkStatusCallbackUrl { get; set; }

        /// <summary>
        /// Payment order id   
        /// </summary>
        [JsonPropertyName("payment_order_id")]
        public Guid PaymentOrderId { get; set; }

        /// <summary>
        /// The payment provider methods available in the checkout   
        /// </summary>
        [JsonPropertyName("payment_provider_methods")]
        public IEnumerable<PaymentProviderMethod> PaymentProviderMethods { get; set; }


        /// <summary>
        /// Supplier of a PaymentLink 
        /// </summary>
        [JsonPropertyName("supplier")]
        public Supplier Supplier { get; set; }


        /// <summary>
        /// Total amount in the smallest denomination  
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// Status of the payment
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Status of sms delivery
        /// </summary>
        [JsonPropertyName("sms_status")]
        public SmsStatus SmsStatus { get; set; }
    }
}
