using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record BankId
    {
        [JsonPropertyName("app_launch_url")]
        public string AppLaunchUrl { get; set; }

        [JsonPropertyName("qr_code")]
        public string QrCode { get; set; }

    }
}
