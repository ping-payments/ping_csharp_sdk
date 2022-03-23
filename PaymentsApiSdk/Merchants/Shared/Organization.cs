using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Merchants.Shared
{
    public record Organization
    {
        /// <summary>
        /// Country code for organization
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set;}

        /// <summary>
        /// Norwegian organization number
        /// </summary>
        [JsonPropertyName("no_organization_number")]
        public string? NoOrganizationNumber { get; set; }

        /// <summary>
        /// Swedish organization number
        /// </summary>
        [JsonPropertyName("se_organization_number")]
        public string? SeOrganizationNumber { get; set; }
    }
}
