using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record Row
    {
        /// <summary>
        /// Description of the product or service
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Quantity of the product or service
        /// </summary>
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// VAT rate of the product or service
        /// </summary>
        [JsonPropertyName("vat_rate")]
        public decimal VatRate { get; set; }

        /// <summary>
        /// Unit price of the product or service, representing the cost for one unit regardless of the given quantity
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Article number of the product or service
        /// </summary>
        [JsonPropertyName("article_number")]
        public string? ArticleNumber { get; set; }


        /// <summary>
        /// Simplifies creation of rows array
        /// </summary>
        public static implicit operator Row[](Row row) => new[] { row };
    }
}
