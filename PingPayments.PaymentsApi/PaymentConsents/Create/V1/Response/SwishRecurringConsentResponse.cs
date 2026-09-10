using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response
{
    public record SwishRecurringConsentResponse
    {
        [JsonPropertyName("payment_request_token")]
        public string? PaymentRequestToken { get; set; }

        [JsonPropertyName("qr_code")]
        public string? QrCode { get; set; }

        [JsonPropertyName("swish_url")]
        public string? SwishUrl { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
