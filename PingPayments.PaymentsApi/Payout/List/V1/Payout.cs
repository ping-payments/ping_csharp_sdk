using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payout.List.V1
{
    public record Payout : GuidResponseBody
    {

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }


        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }
    }
}
