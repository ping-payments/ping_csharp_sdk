using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling
{
    public record SearchBar : BaseStyle
    {
        [JsonPropertyName("text_color")]
        public string? TextColor { get; set; }
    }
}
