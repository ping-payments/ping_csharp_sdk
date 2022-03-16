using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.InitiatePayment.Response
{
    public record Verifone
    {
        public Verifone(string redirectUrl) => RedirectUrl = redirectUrl;

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
