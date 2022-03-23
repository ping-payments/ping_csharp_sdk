using System;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Shared
{
    public record GuidResponseBody : SuccesfulResponseBody
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
