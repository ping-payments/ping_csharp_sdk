using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class OneflowProviderParameters : CreateAgreementProviderParameters
    {
        [property: JsonIgnore]
        public OneflowParty Party { get; set; }
    
        [JsonPropertyName("party")]
        public object party => Party;
    }
}
