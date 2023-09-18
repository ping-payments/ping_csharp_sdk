using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record InvoiceItem
    {
        /// <summary>
        /// Quantity of item
        /// </summary>
        [JsonPropertyName("qty")]
        public int Quantity { get; set; }

        /// <summary>
        /// Item price
        /// </summary>
        [JsonPropertyName("price")]
        public int Price { get; set; }

        /// <summary>
        /// Items VAT rate
        /// </summary>
        [JsonPropertyName("vat")]
        public decimal Vat { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Article number of product to be bought. Will be shown on invoice and will be auto-generated if not provided.
        /// </summary>
        [JsonPropertyName("article_no")]
        public string? ArticleNumber { get; set; }

        /// <summary>
        /// Simplifies creation of invoice items array
        /// </summary>
        public static implicit operator InvoiceItem[](InvoiceItem invoiceItem) => new[] { invoiceItem };
    }
}
