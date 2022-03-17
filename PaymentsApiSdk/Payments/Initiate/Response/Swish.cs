using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.Initiate.Response
{
    public record Swish
    {
        public Swish(string swishUrl) => SwishUrl = swishUrl;

        [JsonPropertyName("swish_url")]
        public string SwishUrl { get; set; }
    }
}
