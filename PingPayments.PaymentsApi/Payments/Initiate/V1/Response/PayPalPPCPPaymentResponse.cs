using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PayPalPPCPPaymentResponse
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
