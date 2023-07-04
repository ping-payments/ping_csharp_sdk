using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update.Oneflow
{
    public record OneflowUpdateAgreementProviderParameters
    {
        [JsonPropertyName("data_fields")]
        public IList<OneflowUpdateAgreementDataField> DataFields { get; set; }
    }
}
