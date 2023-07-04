using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Publish
{
    public class PublishAgreementRequest
    {
        [property: JsonIgnore]
        public Guid AgreementId { get; set; }

        [property: JsonIgnore]
        public PublishAgreementProviderParameters ProviderParameters { get; set; }

        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;
    }
}
