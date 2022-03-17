using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.Initiate.Request
{
    public record OrderItem
    {
        public OrderItem(int amount, string name, decimal vat)
        {
            Amount = amount;
            Name = name;
            Vat = vat;
        }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("vat_rate")]
        public decimal Vat { get; set; }
    }
}
