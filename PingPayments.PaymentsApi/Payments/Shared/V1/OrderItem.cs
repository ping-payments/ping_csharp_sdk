using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record OrderItem
    {
        public OrderItem(int amount, string name, decimal vat, Guid merchantId, IDictionary<string, dynamic>? metadata = null)
        {
            Amount = amount;
            Name = name;
            Vat = vat;
            MerchantId = merchantId;
            Metadata = metadata;
        }

        /// <summary>
        /// Amount in minor currency unit, i ex Swedish Ören
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Name of the item sold
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Vat in decimal percentages, should be between 00.00 and 99.99
        /// </summary>
        [JsonPropertyName("vat_rate")]
        public decimal Vat { get; set; }

        /// <summary>
        /// Merchant that is selling/providing the item
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }

        /// <summary>
        /// Custom metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic>? Metadata { get; set; }

        /// <summary>
        /// Simplifies creation of order items array
        /// </summary>
        public static implicit operator OrderItem[](OrderItem orderItem) => new[] { orderItem };
    }
}
