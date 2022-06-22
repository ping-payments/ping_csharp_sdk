using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Shared
{
    public record ErrorResponseBody
    {
        [JsonPropertyName("errors")]
        public ErrorMessage[] Errors { get; set;}
    }
}
