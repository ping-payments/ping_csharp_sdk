using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record Settlements
    {
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
