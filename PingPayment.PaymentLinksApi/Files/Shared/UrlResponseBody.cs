using PingPayments.PaymentLinksApi.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Files.Shared.V1
{
    public record UrlResponseBody : EmptySuccesfulResponseBody
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
