using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record Verifone
    {
        public Verifone(string redirectUrl) => RedirectUrl = redirectUrl;

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
