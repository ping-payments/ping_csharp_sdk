using PingPayments.KYC.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.AIS
{
    public record AisMerchantRequest
    {
        public AisMerchantRequest
        (
            Guid tenantId,
            Guid merchantId,
            string country,
            Distribution? distribution = null,
            string? email = null,
            string? phoneNumber = null,
            string? psuId = null,
            Redirects? redirects = null,
            Styles? styles = null

        )
        {
            TenantId = tenantId;
            MerchantId = merchantId;
            Country = country;
            Distribution = distribution;
            Email = email;
            PhoneNumber = phoneNumber;
            PsuId = psuId;
            Redirects = redirects;
            Styles = styles;
        }
        /// <summary>
        /// Number of elements per page
        /// </summary>
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Get by Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }

        /// <summary>
        /// Country of merchant
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Number of elements per page
        /// </summary>
        [JsonPropertyName("distribution")]
        public Distribution? Distribution { get; set; }

        /// <summary>
        /// Merchant email
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Merchants phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Merchants psu id
        /// </summary>
        [JsonPropertyName("psu_id")]
        public string? PsuId { get; set; }

        /// <summary>
        /// Object of redirect urls
        /// </summary>
        [JsonPropertyName("redirects")]
        public Redirects? Redirects { get; set; }

        /// <summary>
        /// Merchants phone number
        /// </summary>
        [JsonPropertyName("styles")]
        public Styles? Styles { get; set; }

    }
}
