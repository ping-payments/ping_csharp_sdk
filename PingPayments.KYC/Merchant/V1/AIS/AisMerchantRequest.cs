using PingPayments.KYC.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.AIS
{
    public record AisMerchantRequest
    {
        public AisMerchantRequest
        (
            string country,
            Guid? merchantId = null,
            Distribution? distribution = null,
            string? email = null,
            string? phoneNumber = null,
            string? psuId = null,
            Redirects? redirects = null,
            Styles? styles = null

        )
        {
    
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
        /// Get by Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid? MerchantId { get; set; }

        /// <summary>
        /// Country of merchant
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Way of distribution
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
        /// Style options
        /// </summary>
        [JsonPropertyName("styles")]
        public Styles? Styles { get; set; }

    }
}
