using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record VippsMobilePayResponse
    {
        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }
    }
}
