using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response
{
    public record ActivatePayPalPPCPResponseBody
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("status")]
        public MerchantPaymentProviderMethodActivationStatusEnum Status { get; set; }

        [JsonPropertyName("provider_method_response")]
        public ActivatePayPalPPCPProviderMethodResponse ProviderMethodResponse { get; set; }
    }
}
