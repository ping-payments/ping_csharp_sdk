using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.Mimic.Autogiro.Update.Payment.V1
{
    public record UpdatePaymentRequest
    (
        Guid Id,
       PaymentStatusEnum Status
    )
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Id;


        [JsonPropertyName("status")]
        public PaymentStatusEnum Status { get; set; } = Status;
    }
}

