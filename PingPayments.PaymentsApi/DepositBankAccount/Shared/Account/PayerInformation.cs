using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.Shared
{
    public record PayerInformation
    {
        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("street_address")]
        public string? StreetAddress { get; set; }
    }

}