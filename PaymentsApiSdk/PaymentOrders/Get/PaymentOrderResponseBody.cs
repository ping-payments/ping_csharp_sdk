using PaymentsApiSdk.PaymentOrders.Shared;
using PaymentsApiSdk.Payments.Get;
using PaymentsApiSdk.Shared;
using System;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.PaymentOrders.Get
{
    public record PaymentOrderResponseBody : GuidResponseBody
    {
        [JsonPropertyName("status")]
        public PaymentOrderStatusEnum Status { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("payments")]
        public PaymentResponseBody[] Payments { get; set; }

        [JsonPropertyName("split_tree_id")]
        public Guid SplitTreeId { get; set; }
    }
}
