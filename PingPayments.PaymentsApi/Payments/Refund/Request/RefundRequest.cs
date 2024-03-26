using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Refund.V1
{
    public record RefundRequest(int Amount, CurrencyEnum Currency, RefundReasonEnum Reason, string? Description = "")
    {
        /// <summary>
        /// Amount to be refunded. OBS, must equal payment amount
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; } = Amount;

        /// <summary>
        /// Currency used for this refund
        /// </summary>
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; } = Currency;

        /// <summary>
        /// An arbitrary string where you can provide more context for the refund
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; } = Description;

        /// <summary>
        /// Reason for the refund
        /// </summary>
        [JsonPropertyName("reason")]
        public RefundReasonEnum Reason { get; set; } = Reason;
    }
}
