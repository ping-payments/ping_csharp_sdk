using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public abstract record BasePaymentLinks : EmptySuccesfulResponseBody
    {
        /// <summary>
        /// Checkout url for paymentLink 
        /// </summary>
        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }

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
        ///  whether the PaymentLink is distributed by email 
        /// </summary>
        [JsonPropertyName("distributed_by_email")]
        public bool? DistributedByEmail { get; set; }

        /// <summary>
        ///  Due date for the payment 
        /// </summary>
        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        ///  Invoice adress for the payment  
        /// </summary>
        [JsonPropertyName("invoice_address")]
        public Adress? InvoiceAdress { get; set; }

        /// <summary>
        ///  whether the an invoice is created 
        /// </summary>
        [JsonPropertyName("invoice_created")]
        public bool? InvoiceCreated { get; set; }

        /// <summary>
        ///  Items iclueded in the PaymentLink 
        /// </summary>
        [JsonPropertyName("items")]
        public IEnumerable<Item>? Items { get; set; }

        /// <summary>
        /// Local of where the PaymentLink is processed
        /// </summary>
        [JsonPropertyName("locale")]
        public string? Local { get; set; }

        /// <summary>
        ///Image of Logo wich is visible on the PaymenLink  
        /// </summary>
        [JsonPropertyName("logo_image_link")]
        public string? LogoImageLink { get; set; }

        /// <summary>
        /// Custom metadata for payment link 
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic>? Metadata { get; set; }

        /// <summary>
        /// Payment id  
        /// </summary>
        [JsonPropertyName("payment_id")]
        public Guid? PaymentId { get; set; }

        /// <summary>
        /// Payment Link id  
        /// </summary>
        [JsonPropertyName("payment_link_id")]
        public Guid PaymentLinkId { get; set; }

        /// <summary>
        /// Callback url for checking the status of a PaymentLink  
        /// </summary>
        [JsonPropertyName("payment_link_status_callback_url")]
        public Guid? PaymentLinkStatusCallbackUrl { get; set; }

        /// <summary>
        /// Payment order id   
        /// </summary>
        [JsonPropertyName("payment_order_id")]
        public Guid? PaymentOrderId { get; set; }

        /// <summary>
        /// Payment order id   
        /// </summary>
        [JsonPropertyName("payment_provider_methods")]
        public PaymentProviderMethods? PaymentProviderMethods { get; set; }

        /// <summary>
        /// Status for SMS 
        /// </summary>
        [JsonPropertyName("sms_status")]
        public SmsStatus? SmsStatus { get; set; }

        /// <summary>
        /// Status for PaymentLink 
        /// </summary>
        [JsonPropertyName("status")]
        public Status? Status { get; set; }

        /// <summary>
        /// Tenant id 
        /// </summary>
        [JsonPropertyName("tenant_id")]
        public Guid? Tenant_id { get; set; }

        /// <summary>
        /// Total amount in the smallest denomination  
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

    }
}
