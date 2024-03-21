using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record PaymentResponseBody : BasePayment
    {
        /// <summary>
        /// Id of a Payment
        /// </summary>
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Status of a Payment
        /// </summary>
        [JsonPropertyName("status")]
        public PaymentStatusEnum Status { get; set; }

        /// <summary>
        /// History of Payment status updates
        /// </summary>
        [JsonPropertyName("status_history")]
        public StatusHistory[]? StatusHistory { get; set; }

        /// <summary>
        /// Shows refund information if not null
        /// </summary>
        [JsonPropertyName("refund")]
        public Shared.V1.Refund? Refund { get; set; }
    }
}
