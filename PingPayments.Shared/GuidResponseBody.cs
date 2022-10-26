using System;
using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record GuidResponseBody 
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
