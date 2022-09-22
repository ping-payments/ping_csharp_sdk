using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared.V1
{
    public record PaymentOrder : GuidResponseBody
    {
        [JsonPropertyName("status")]
        public PaymentOrderStatusEnum Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("currency")]
        public CurrencyEnum currency { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("payments")]
        public PaymentResponseBody[] Payments { get; set; } = Array.Empty<PaymentResponseBody>();

        [JsonPropertyName("split_tree_id")]
        public Guid? SplitTreeId { get; set; }
    }
}
