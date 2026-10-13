using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivateQuickpayParameters
    {
        public ActivateQuickpayParameters(string email, string? addressLine = null, string? city = null, string? postalCode = null)
        {
            Email = email;
            AddressLine = addressLine;
            City = city;
            PostalCode = postalCode;
        }

        [JsonPropertyName("email")]
        public string Email { get; }

        /// <summary>
        /// Optional. The merchant's stored address is used when address fields are omitted.
        /// </summary>
        [JsonPropertyName("address_line")]
        public string? AddressLine { get; }

        [JsonPropertyName("city")]
        public string? City { get; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; }
    }
}
