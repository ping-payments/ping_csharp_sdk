using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record ProviderMethodBase
    {
        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }
    }
}
