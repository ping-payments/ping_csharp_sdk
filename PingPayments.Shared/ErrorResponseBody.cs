using System.Text.Json.Serialization;

namespace PingPayments.Shared
{
    public record ErrorResponseBody
    {
        [JsonPropertyName("errors")]
        public ErrorMessage[]? Errors { get; set;}

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
