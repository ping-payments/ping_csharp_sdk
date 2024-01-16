using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared
{
    public record SessionStatusHistory
    {
        [JsonPropertyName("details")]
        public Details? Details { get; set; }

        [JsonPropertyName("occurred_at")]
        public DateTime OccurredAt { get; set; }

        [JsonPropertyName("status")]
        public AccountVerificationStatusEnum Status { get; set; }
    }
}
