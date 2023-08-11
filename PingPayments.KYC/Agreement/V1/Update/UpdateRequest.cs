using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update
{
    public record UpdateRequest
    {
        /// <summary>
        /// Id of the agreement to be updated
        /// </summary>
        public Guid AgreementId { get; set; }

        [property: JsonIgnore]
        public UpdateProviderParameters ProviderParameters { get; set; }

        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;
    }
}
