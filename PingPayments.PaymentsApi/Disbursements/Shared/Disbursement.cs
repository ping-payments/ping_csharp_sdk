using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;


namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record Disbursement : GuidResponseBody
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }


        [JsonPropertyName("disbursed_at")]
        public DateTime DisbursedAt { get; set; }


        [JsonPropertyName("manual_corrections")]
        public ManualCorrections[] ManualCorrections { get; set; }


        [JsonPropertyName("settlements")]
        public Settlements[] Settlemnts { get; set; }
    }
}
