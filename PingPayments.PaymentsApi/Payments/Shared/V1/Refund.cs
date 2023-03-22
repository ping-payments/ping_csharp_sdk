using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Refund
    {
        /// <summary>
        /// Refunded amount
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }


        /// <summary>
        /// When the Payment was refunded
        /// </summary>
        [JsonPropertyName("refunded_at")]
        public string RefundedAt { get; set; }
    }
}
