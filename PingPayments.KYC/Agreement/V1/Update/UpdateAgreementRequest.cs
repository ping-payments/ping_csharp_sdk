using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update
{
    public record UpdateAgreementRequest
    {
        public Guid AgreementId { get; set; }

        [property: JsonIgnore]
        public UpdateAgreementProviderParameters ProviderParameters { get; set; }

        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;
    }
}
