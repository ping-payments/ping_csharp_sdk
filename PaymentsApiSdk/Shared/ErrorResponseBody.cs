using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Shared
{
    public record ErrorResponseBody()
    {
        [JsonPropertyName("errors")]
        public ErrorMessage[] Errors { get; set;}
    }
}
