using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Shared
{
    public record ErrorResponseBody
    {
        [JsonPropertyName("errors")]
        public ErrorMessage[] Errors { get; set;}
    }
}
