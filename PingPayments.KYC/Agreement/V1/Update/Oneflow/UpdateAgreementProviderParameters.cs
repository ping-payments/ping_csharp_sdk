using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update.Oneflow
{
    public class UpdateAgreementProviderParameters : UpdateProviderParameters
    {
        [JsonPropertyName("data_fields")]
        public IList<UpdateAgreementDataField> DataFields { get; set; }
    }
}
