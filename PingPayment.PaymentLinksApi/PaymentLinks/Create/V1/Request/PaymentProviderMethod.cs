using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System.Text.Json.Serialization;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record PaymentProviderMethod
    {
        public PaymentProviderMethod(MethodEnum method, ProviderEnum provider, Dictionary<string, dynamic>? parameters = null)
        {
            Method = method;
            Provider = provider;
            Parameters = parameters;
        }

        /// <summary>
        /// Payment method   
        /// </summary>
        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        /// <summary>
        /// Payment method provider  
        /// </summary>
        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }

        /// <summary>
        /// Parameters for making a payment 
        /// </summary>
        [JsonPropertyName("parameters")]
        public Dictionary<string, dynamic>? Parameters { get; set; }
    }
}
