using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record MerchantPaymentProviderMethodActivationCallback
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("status")]
        public MerchantPaymentProviderMethodActivationStatusEnum Status { get; set; }

        [JsonPropertyName("details")]
        public IDictionary<string, dynamic>? Details { get; set; }
    }
}
