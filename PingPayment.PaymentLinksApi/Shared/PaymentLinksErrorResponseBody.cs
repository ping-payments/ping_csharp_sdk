using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Shared
{
    public record PaymentLinksErrorResponseBody
    {

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("property")]
        public string? Property { get; set; }

        [JsonPropertyName("additional_information")]
        public IDictionary<string, dynamic>? AdditionalInformation { get; set; }

    }
}
