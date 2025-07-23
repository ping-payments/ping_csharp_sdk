using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record PaginationLinkHref
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
