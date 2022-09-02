using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payouts.Shared
{
    public record PayoutResponseBody : GuidResponseBody
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }
    }
}
