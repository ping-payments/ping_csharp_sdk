using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class CreateRequestBody
    {
        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [property: JsonIgnore]
        public CreateAccessLinkProviderParameters ProviderParameters { get; set; }

        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;

    }
}
