using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record ActivateKlarnaHPPProviderMethodResponse
    {
        [JsonPropertyName("redirect_url")]
        public string? RedirectUrl { get; set; }
    }
}
