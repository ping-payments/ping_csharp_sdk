using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record ErrorResponseBody
    {
        [JsonPropertyName("errors")]
        public ErrorMessage[] Errors { get; set; }
    }
}
