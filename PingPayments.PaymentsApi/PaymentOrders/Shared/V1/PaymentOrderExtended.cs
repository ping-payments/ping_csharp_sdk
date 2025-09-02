using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared.V1
{
    public record PaymentOrderExtended : PaymentOrder
    {
        [JsonPropertyName("payments")]
        public Payment[] Payments { get; set; } = Array.Empty<Payment>();
    }
}
