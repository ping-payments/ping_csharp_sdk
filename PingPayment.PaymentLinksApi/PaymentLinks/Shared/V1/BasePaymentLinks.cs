using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public abstract record BasePaymentLinks : EmptySuccesfulResponseBody
    {
        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("delivery_address")]
        public Adress DeliveryAdress { get; set; }

        [JsonPropertyName("distributed_by_email")]
        public bool DistributedByEmail { get; set; }

        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        [JsonPropertyName("invoice_address")]
        public Adress InvoiceAdress { get; set; }

        [JsonPropertyName("invoice_created")]
        public bool InvoiceCreated { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Item> Items { get; set; }
        
        [JsonPropertyName("locale")]
        public string Local { get; set; }

        [JsonPropertyName("logo_image_link")]
        public string LogoImageLink { get; set; }

        /// <summary>
        /// Custom metadata for payment link 
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        [JsonPropertyName("payment_id")]
        public Guid PaymentId { get; set; }
        
        [JsonPropertyName("payment_link_id")]
        public Guid PaymentLinkId { get; set; }
        
        [JsonPropertyName("payment_link_status_callback_url")]
        public Guid PaymentLinkStatusCallbackUrl { get; set; }
        
        [JsonPropertyName("payment_order_id")]
        public Guid PaymentOrderId { get; set; }

        [JsonPropertyName("payment_provider_methods")]
        public PaymentProviderMethods PaymentProviderMethods { get; set; }


    }
}
