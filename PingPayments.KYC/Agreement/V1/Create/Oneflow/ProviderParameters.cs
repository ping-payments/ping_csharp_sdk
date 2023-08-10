using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class ProviderParameters : CreateAgreementProviderParameters
    {
        [property: JsonIgnore]
        public Party Party { get; set; }

        [JsonPropertyName("party")]
        public object party => Party;
    }
}
