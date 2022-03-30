using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record SwishMobileResponse : ProviderMethodResponseBody
    {
        public SwishMobileResponse(string swishUrl) => SwishUrl = swishUrl;

        [JsonPropertyName("swish_url")]
        public string SwishUrl { get; set; }
    }
}
