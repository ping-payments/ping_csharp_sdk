using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record FortusResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public FortusResponse ProviderMethodResponse { get; set; }

    }
}
