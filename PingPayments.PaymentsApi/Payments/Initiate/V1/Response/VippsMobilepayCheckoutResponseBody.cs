using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record VippsMobilepayCheckoutResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public VippsMobilepayCheckoutResponse ProviderMethodResponse { get; set; }
    }
}
