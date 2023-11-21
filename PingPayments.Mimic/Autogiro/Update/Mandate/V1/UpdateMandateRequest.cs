using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.Mimic.Autogiro.Update.Mandate.V1
{
    public record UpdateMandateRequest
    (
        Guid Id,
        MandateStatusEnum Status
    )
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = Id;


        [JsonPropertyName("status")]
        public MandateStatusEnum Status { get; set; } = Status;
    }
}

