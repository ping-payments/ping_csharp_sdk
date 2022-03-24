using PingPayments.PaymentsApi.Payments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Get
{
    public record PaymentResponseBody : BasePayment
    {
        [JsonPropertyName("id")]
        public Guid Id {get; set;}

        [JsonPropertyName("status")]
        public PaymentStatusEnum Status { get; set; }     
    }
}
