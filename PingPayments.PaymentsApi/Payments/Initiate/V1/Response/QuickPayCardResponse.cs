using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record QuickPayCardResponse
    {
        [JsonPropertyName("payment_link_url")]
        public string PaymentLinkUrl { get; set; }
    }
}
