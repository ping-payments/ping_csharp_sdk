
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System.Text.Json.Serialization;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record PaymentProviderMethod
    {
        public PaymentProviderMethod(MethodEnum method, ProviderEnum provider, ProviderMethodParameters? parameters = null)
        {
            Method = method;
            Parameters = parameters;
            Provider = provider;
        }
        /// <summary>
        /// TODO Fyll i rätt besrkivning   
        /// </summary>
        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        /// <summary>
        /// TODO Fyll i rätt besrkivning  
        /// </summary>
        [JsonPropertyName("parameters")]
        public ProviderMethodParameters? Parameters { get; set; }

        /// <summary>
        /// TODO Fyll i rätt besrkivning   
        /// </summary>
        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }
    }
}
