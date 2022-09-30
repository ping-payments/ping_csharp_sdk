using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public record PaymentProviderMethod : ProviderMethodBase
    {
        public PaymentProviderMethod(MethodEnum method, ProviderEnum provider, Dictionary<string, dynamic>? parameters = null)
        {
            Method = method;
            Provider = provider;
            Parameters = parameters;
        }
        /// <summary>
        /// Parameters for making a payment 
        /// </summary>
        [JsonPropertyName("parameters")]
        public Dictionary<string, dynamic>? Parameters { get; set; }
    }
}
