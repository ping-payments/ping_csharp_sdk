using PaymentsApiSdk.Payments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.Get
{
    public record PaymentResponseBody : BasePayment
    {
        [JsonPropertyName("id")]
        public Guid Id {get; set;}

        [JsonPropertyName("status")]
        public PaymentStatusEnum Status { get; set; }     
    }
}
