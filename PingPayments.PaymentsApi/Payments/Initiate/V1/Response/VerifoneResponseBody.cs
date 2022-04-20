using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record VerifoneResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public VerifoneResponse ProviderMethodResponse { get; set; }        
    }
}
