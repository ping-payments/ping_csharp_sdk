using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PaymentIqResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public PaymentIqResponse ProviderMethodResponse { get; set; }
    }
}
