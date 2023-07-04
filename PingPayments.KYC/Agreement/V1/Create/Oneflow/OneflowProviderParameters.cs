using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class OneflowProviderParameters : ICreateAgreementProviderParameters
    {
        [JsonPropertyName("party")]
        public OneflowParty Party { get; set; }
    }
}
