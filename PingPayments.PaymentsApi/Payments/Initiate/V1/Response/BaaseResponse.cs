using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record BaaseResponse
    {
        [JsonPropertyName("qr_code")]
        public string QrCode { get; set; }

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
    }
}

