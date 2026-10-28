using System;
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
        public string? Name { get; set; } = null;

        /// <summary>
        /// Unique identifier, for Nordic countries use organization number, otherwise use VAT number
        /// </summary>
        [JsonPropertyName("identifier")]
        public string? Identifier { get; set; } = null;

        /// <summary>
        /// KYC information
        /// </summary>
        [JsonPropertyName("kyc_information")]
        public KycInformation? KycInformation { get; set; }

        /// <summary>
        /// Norwegian organization number
        /// </summary>
        [Obsolete("Use Identifier instead.")]
        [JsonPropertyName("no_organization_number")]
        public string? NoOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Danish organization number
        /// </summary>
        [Obsolete("Use Identifier instead.")]
        [JsonPropertyName("dk_organization_number")]
        public string? DkOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Swedish organization number
        /// </summary>
        [Obsolete("Use Identifier instead.")]
        [JsonPropertyName("se_organization_number")]
        public string? SeOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Finnish organization number
        /// </summary>
        [Obsolete("Use Identifier instead.")]
        [JsonPropertyName("fi_organization_number")]
        public string? FiOrganizationNumber { get; set; } = null;

        /// <summary>
        /// German VAT identification number
        /// </summary>
        [Obsolete("Use Identifier instead.")]
        [JsonPropertyName("de_vat_identification_number")]
        public string? DeOrganizationNumber { get; set; } = null;

        /// <summary>
        /// Austrian VAT identification number
        /// </summary>
        [Obsolete("Use Identifier instead.")]
        [JsonPropertyName("at_vat_identification_number")]
        public string? AtOrganizationNumber { get; set; } = null;
    }
}
