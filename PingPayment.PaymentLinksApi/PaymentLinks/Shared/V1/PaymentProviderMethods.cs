using PingPayments.PaymentLinksApi.Payments.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record PaymentProviderMethods
    {

        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }
    }
}