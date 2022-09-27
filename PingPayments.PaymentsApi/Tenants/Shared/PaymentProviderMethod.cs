using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Tenants.Shared
{
    public record PaymentProviderMethod
    {
        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }
    }
}