using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response
{
    public record BankgirotAutogiroConsentResponse
    {
        [JsonPropertyName("sign_url")]
        public string? SignUrl { get; set; }
    }
}
