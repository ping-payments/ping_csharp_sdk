using System;
using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record GuidResponseBody : EmptySuccesfulResponseBody
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
