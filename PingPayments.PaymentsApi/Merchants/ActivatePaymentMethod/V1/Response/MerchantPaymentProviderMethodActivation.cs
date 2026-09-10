using PingPayments.PaymentsApi.Merchants.Shared.V1;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record MerchantPaymentProviderMethodActivation
    {
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("merchant")]
        public Merchant Merchant { get; set; }

        [JsonPropertyName("status")]
        public MerchantPaymentProviderMethodActivationStatusEnum Status { get; set; }

        [JsonPropertyName("status_history")]
        public MerchantPaymentProviderMethodActivationStatus[]? StatusHistory { get; set; }
    }
}
