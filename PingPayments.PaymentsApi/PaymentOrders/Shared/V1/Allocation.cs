using PingPayments.PaymentsApi.Disbursements.Shared;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared.V1
{

    public record Allocation : GuidResponseBody
    {

        [JsonPropertyName("allocated_at")]
        public DateTimeOffset AllocatedAt { get; set; }

        [JsonPropertyName("disbursement_id")]
        public Guid? DisbursementId { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }

        [JsonPropertyName("payment_id")]
        public Guid? PaymentId { get; set; }

        [JsonPropertyName("payment_order_id")]
        public Guid PaymentOrderId { get; set; }

        [JsonPropertyName("recipient_name")]
        public string RecipientName { get; set; }

        [JsonPropertyName("recipient_type")]
        public RecipientTypeEnum RecipientType { get; set; }
    }
}
