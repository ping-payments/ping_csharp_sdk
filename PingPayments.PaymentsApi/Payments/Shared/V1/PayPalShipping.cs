using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record PayPalShipping
    {
        [JsonPropertyName("address")]
        public PayPalShippingAddress? Address { get; set; }

        [JsonPropertyName("cost")]
        public int? Cost { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("phone_number")]
        public PayPalPhoneNumber? PhoneNumber { get; set; }

        [JsonPropertyName("preference")]
        public PayPalShippingPreferenceEnum Preference { get; set; }
    }
}
