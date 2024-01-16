using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling
{
    public record BaseStyle
    {
        [JsonPropertyName("background_color")]
        public string? BackgroundColor { get; set; }
    }
}
