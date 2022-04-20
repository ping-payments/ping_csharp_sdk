using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PaymentIqResponse 
    {
        [JsonPropertyName("pay_url")]
        public string PayUrl { get; set; }
    }
}
