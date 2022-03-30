using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PaymentIqResponse : ProviderMethodResponseBody
    {
        public PaymentIqResponse(string payUrl) => PayUrl = payUrl;

        [JsonPropertyName("pay_url")]
        public string PayUrl { get; set; }
    }
}
