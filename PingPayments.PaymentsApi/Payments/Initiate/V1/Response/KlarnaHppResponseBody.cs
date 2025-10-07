using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record KlarnaHppResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public KlarnaHppResponse ProviderMethodResponse { get; set; }
    }
}
