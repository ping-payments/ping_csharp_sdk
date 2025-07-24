using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared.V1
{
    public record PaymentOrder : GuidResponseBody
    {
        /// <summary>Status of a Payment Order. [OPEN, CLOSED, SPLIT, SETTLED]</summary>
        [JsonPropertyName("status")]
        public PaymentOrderStatusEnum Status { get; set; }

        /// <summary>Point in time when Payment Order was created</summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }

        //[JsonPropertyName("payments")]
        //public PaymentResponseBody[] Payments { get; set; } = Array.Empty<PaymentResponseBody>();

        /// <summary>The Split Tree used to split this Payment Order</summary>
        [JsonPropertyName("split_tree_id")]
        public Guid? SplitTreeId { get; set; }
    }
}
