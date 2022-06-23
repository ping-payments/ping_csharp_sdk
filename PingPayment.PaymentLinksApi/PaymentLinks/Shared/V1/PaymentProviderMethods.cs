using PingPayments.PaymentLinksApi.Payments.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record PaymentProviderMethods
    {
        /// <summary>
        /// The payment method 
        /// </summary>
        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        /// <summary>
        /// The provider method parameters
        /// </summary>
        [JsonPropertyName("parameters")]
        public Dictionary<string, dynamic>? Parameters { get; set; }

        /// <summary>
        /// The provider for a payment 
        /// </summary>
        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }
    }
}