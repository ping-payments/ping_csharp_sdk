﻿using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class CreateAccessLinkRequestBody
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
        public CreateAccessLinkProviderParameters ProviderParameters { get; set; }

        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;

    }
}
