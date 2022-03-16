using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.InitiatePayment.Response
{
    public record Swish
    {
        public Swish(string swishUrl) => SwishUrl = swishUrl;

        [JsonPropertyName("swish_url")]
        public string SwishUrl { get; set; }
    }
}
