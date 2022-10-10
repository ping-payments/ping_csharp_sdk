﻿using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record StatusHistory
    {
        /// <summary>
        /// Details of the Payment status update
        /// </summary>
        [JsonPropertyName("details")]
        public Details? Details { get; set; }

        /// <summary>
        /// Timestamp at which the status event was logged
        /// </summary>
        [JsonPropertyName("occurred_at")]
        public DateTime? OccurredAt { get; set; }

        /// <summary>
        /// Status of a Payment
        /// </summary>
        [JsonPropertyName("status")]
        public PaymentStatusEnum? Status { get; set; }
    }
}