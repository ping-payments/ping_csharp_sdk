using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record QuickPayCardResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public QuickPayCardResponse ProviderMethodResponse { get; set; }
    }
}
