using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record KycStatus
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("status")]
        public KycStatusEnum Status { get; set; }
    }
}
