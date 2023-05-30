using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update
{
    public record OneFlowUpdateAgreementProviderParameters
    {
        [JsonPropertyName("data_fields")]
        public Dictionary<string, object> DataFields { get; set; }
    }
}
