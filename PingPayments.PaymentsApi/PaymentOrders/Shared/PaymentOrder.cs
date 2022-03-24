using PingPayments.PaymentsApi.PaymentOrders.Shared;
using PingPayments.PaymentsApi.Payments.Get;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared
{
    public record PaymentOrder : GuidResponseBody
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
