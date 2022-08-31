using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record BaaseResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public BaaseResponse ProviderMethodResponse { get; set; }
    }
}
