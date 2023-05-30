using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Publish
{
    public class PublishAgreementRequest
    {
        public Guid AgreementId { get; set; }

        [JsonPropertyName("provider_parameters")]
        public IPublishAgreementProviderParameters ProviderParameters { get; set; }
    }
}
