using System;
using System.Text.Json.Serialization;

namespace PingPayments.Mimic.Disbursements.Trigger.V1
{
    public record FailedDisbursement
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("payment_order_id")]
        public Guid PaymentOrderId { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
