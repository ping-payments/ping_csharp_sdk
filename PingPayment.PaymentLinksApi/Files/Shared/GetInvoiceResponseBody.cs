using PingPayments.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Files.Shared.V1
{
    public record GetInvoiceResponseBody : EmptySuccessfulResponseBody
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("reference_type")]
        public string ReferenceType { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
    }
}
