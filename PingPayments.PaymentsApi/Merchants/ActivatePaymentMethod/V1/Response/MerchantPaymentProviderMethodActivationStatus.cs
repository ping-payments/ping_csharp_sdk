using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record MerchantPaymentProviderMethodActivationStatus
    {
        [JsonPropertyName("details")]
        public IDictionary<string, dynamic>? Details { get; set; }

        [JsonPropertyName("occurred_at")]
        public DateTime OccurredAt { get; set; }

        [JsonPropertyName("status")]
        public MerchantPaymentProviderMethodActivationStatusEnum Status { get; set; }
    }
}
