using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Get.V1
{
    public record PaymentResponseBody : BasePayment
    {
        [JsonPropertyName("id")]
        public Guid Id {get; set;}

        [JsonPropertyName("status")]
        public PaymentStatusEnum Status { get; set; }     
    }
}
