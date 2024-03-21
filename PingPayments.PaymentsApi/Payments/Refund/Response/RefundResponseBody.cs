using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record RefundResponseBody
    {
        /// <summary>
        /// Refunded amount
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Currency code of refund
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Provider of refund
        /// </summary>
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Status of refund
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
