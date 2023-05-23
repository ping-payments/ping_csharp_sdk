using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Item
    {
        public Item(string description, Guid merchantId, int price, int quantity, decimal vat, string? itemNumber = null, string? unit = "st", IDictionary<string, dynamic>? metadata = null, string[]? tags = null)
        {
            Description = description;
            MerchantId = merchantId;
            Price = price;
            Quantity = quantity;
            Vat = vat;
            ItemNumber = itemNumber;
            Unit = unit;
            Metadata = metadata ?? new Dictionary<string, dynamic>();
            Tags = tags ?? Array.Empty<string>();
        }

        /// <summary>
        /// The description of the Item
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Merchant Id
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }

        /// <summary>
        /// The price/unit in the smallest denomination
        /// </summary>
        [JsonPropertyName("price")]
        public int Price { get; set; }

        /// <summary>
        /// The quantity of the Item
        /// </summary>
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The vat percentage
        /// </summary>
        [JsonPropertyName("vat")]
        public decimal Vat { get; set; }

        /// <summary>
        /// Item identifier
        /// </summary>
        [JsonPropertyName("item_number")]
        public string? ItemNumber { get; set; }

        /// <summary>
        /// The unit of the Item, deafult "st"
        /// </summary>
        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        /// <summary>
        /// Custom metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        /// <summary>
        /// Set tags on an item to route funds
        /// </summary>
        [JsonPropertyName("tags")]
        public string[]? Tags { get; set; }

        /// <summary>
        /// Simplifies creation of  items array
        /// </summary>
        public static implicit operator Item[](Item Item) => new[] { Item };
    }
}