using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Update.Oneflow
{
    public record UpdateAgreementDataField
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
