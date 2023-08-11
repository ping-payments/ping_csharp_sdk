using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Publish
{
    public class PublishRequest
    {
        [property: JsonIgnore]
        public Guid AgreementId { get; set; }

        [property: JsonIgnore]
        public PublishProviderParameters ProviderParameters { get; set; }

        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;
    }
}
