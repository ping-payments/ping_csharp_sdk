using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling
{
    public record Modal : BaseStyle
    {
        [JsonPropertyName("text_color")]
        public string? TextColor { get; set; }

        [JsonPropertyName("subtext_color")]
        public string? SubTextColor { get; set; }
    }
}
