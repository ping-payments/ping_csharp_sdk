using PingPayments.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Files.Shared.V1
{
    public record UrlResponseBody : EmptySuccessfulResponseBody
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
