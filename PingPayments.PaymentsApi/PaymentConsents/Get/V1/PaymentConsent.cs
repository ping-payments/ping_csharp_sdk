using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentConsents.Get.V1
{
    public record PaymentConsent : GuidResponseBody
    {
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }

        [JsonPropertyName("signee")]
        public Payer? Signee { get; set; }

        [JsonPropertyName("status")]
        public PaymentConsentStatusEnum Status { get; set; }
    }
}
