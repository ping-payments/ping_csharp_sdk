using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling
{
    public record ListStyle : BaseStyle
    {
        [JsonPropertyName("hover_color")]
        public string? HoverColor { get; set; }
    }
}
