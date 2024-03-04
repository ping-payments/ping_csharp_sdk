using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record Row
    {
        /// <summary>
        /// Url to display the invoice
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("vat_rate")]
        public string VatRate { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("article_number")]
        public string? ArticleNumber { get; set; }


        /// <summary>
        /// Simplifies creation of rows array
        /// </summary>
        public static implicit operator Row[](Row row) => new[] { row };
    }
}
