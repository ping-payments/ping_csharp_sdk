using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class CreateRequestBody
    {

        /// <summary>
        /// Id of a specific agreement
        /// </summary>
        [property: JsonIgnore]
        public Guid AgreementId { get; set; }

        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [property: JsonIgnore]
        public ProviderParameters ProviderParameters { get; set; }

        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;

    }
}
