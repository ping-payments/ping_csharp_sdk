using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PingDepositResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public PingDepositResponse ProviderMethodResponse { get; set; }
    }
}
