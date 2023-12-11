using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record LegalEntity
    {
        /// <summary>
        /// Two letter ISO 3166-2 country code
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Unique identifier, e.g. personal identification number, organization number
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Type denoting whether the legal entity is an organization or a person
        /// </summary>
        [JsonPropertyName("type")]
        public LegalEntityEnum Type { get; set; }
    }
}
