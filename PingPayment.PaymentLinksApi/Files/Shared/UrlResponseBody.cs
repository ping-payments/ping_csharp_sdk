using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Files.Shared
{
    public record UrlResponseBody : EmptySuccesfulResponseBody
    {

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
