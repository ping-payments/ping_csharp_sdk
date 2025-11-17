using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public record Organization
    {
        /// <summary>
        /// Country code for organization
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Name of the organization
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// KYC information
        /// </summary>
        [JsonPropertyName("kyc_information")]
        public KycInformation? KycInformation { get; set; }

        /// <summary>
        /// Norwegian organization number
        /// </summary>
        [JsonPropertyName("no_organization_number")]
        public string? NoOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Norwegian organization number
        /// </summary>
        [JsonPropertyName("dk_organization_number")]
        public string? DkOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Swedish organization number
        /// </summary>
        [JsonPropertyName("se_organization_number")]
        public string? SeOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Finnish organization number
        /// </summary>
        [JsonPropertyName("fi_organization_number")]
        public string? FiOrganizationNumber { get; set; } = null;

        /// <summary>
        /// German VAT identification number
        /// </summary>
        [JsonPropertyName("de_organization_number")]
        public string? DeOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Austrian VAT identification number
        /// </summary>
        [JsonPropertyName("at_organization_number")]
        public string? AtOrganizationNumber { get; set; } = null;
    }
}
