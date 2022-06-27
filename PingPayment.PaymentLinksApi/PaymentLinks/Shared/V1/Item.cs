using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Item
    {
        /// <summary>
        /// The description of the Item
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Item identifier
        /// </summary>
        [JsonPropertyName("item_number")]
        public string ItemNumber { get; set; }

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
        /// The unit of the Item, deafult "st"
        /// </summary>
        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The vat percentage
        /// </summary>
        [JsonPropertyName("vat")]
        public decimal Vat { get; set; }


        /// <summary>
        /// Simplifies creation of  items array
        /// </summary>
        public static implicit operator Item[](Item Item) => new[] { Item };
    }
}