using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record ManualCorrections
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("no_organization_number")]
        public string? NoOrganizationNumber { get; set; }

        [JsonPropertyName("se_organization_number")]
        public string? SeOrganizationNumber { get; set; }
    }
}
