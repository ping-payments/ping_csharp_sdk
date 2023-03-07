using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;


namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record Disbursement : GuidResponseBody
    {
        /// <summary>
        /// Amount in minor currency unit
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }


        /// <summary>
        /// Amount in minor currency unit
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }


        /// <summary>
        /// Timestamp at which the disbursement was initiated
        /// </summary>
        [JsonPropertyName("disbursed_at")]
        public DateTimeOffset DisbursedAt { get; set; }


        /// <summary>
        /// List of manual corrections
        /// </summary>
        [JsonPropertyName("manual_corrections")]
        public ManualCorrections[] ManualCorrections { get; set; }


        /// <summary>
        /// List of settlements
        /// </summary>
        [JsonPropertyName("settlements")]
        public Settlement[] Settlemnts { get; set; }
    }
}
