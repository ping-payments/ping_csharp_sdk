using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record ActivatePayPalPPCPProviderMethodResponse
    {
        [JsonPropertyName("action_url")]
        public string ActionUrl { get; set; }
    }
}
