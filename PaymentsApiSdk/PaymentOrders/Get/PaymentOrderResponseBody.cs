using PaymentsApiSdk.PaymentOrders.Shared;
using PaymentsApiSdk.Payments.Get;
using PaymentsApiSdk.Payments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.PaymentOrders.Get
{
    public record PaymentOrderResponseBody : BasePayment
    {
        [JsonPropertyName("id")]
        public Guid Id {get; set;}

        [JsonPropertyName("status")]
        public PaymentOrderStatusEnum Status { get; set; }
        
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("payments")]
        public PaymentResponseBody[] Payments { get; set; }
    }
}
