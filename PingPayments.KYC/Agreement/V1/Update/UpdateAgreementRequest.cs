using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update
{
    public record UpdateAgreementRequest
    {
        public Guid AgreementId { get; set; }

        [JsonPropertyName("provider_parameters")]
        public IUpdateAgreementProviderParameters ProviderParameters { get; set; }
    }
}
