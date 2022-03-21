using System;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.Shared
{
    public record OrderItem
    {
        public OrderItem(int amount, string name, decimal vat, Guid merchantId)
        {
            Amount = amount;
            Name = name;
            Vat = vat;
            MerchantId = merchantId;
        }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("vat_rate")]
        public decimal Vat { get; set; }
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }
    }
}
