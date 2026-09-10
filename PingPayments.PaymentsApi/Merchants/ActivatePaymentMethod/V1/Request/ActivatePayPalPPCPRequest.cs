using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivatePayPalPPCPRequest
    {
        public ActivatePayPalPPCPRequest(ActivatePayPalPPCPParameters providerMethodParameters, Uri? statusCallbackUrl = null)
        {
            Method = MethodEnum.ppcp;
            Provider = ProviderEnum.paypal;
            ProviderMethodParameters = providerMethodParameters;
            StatusCallbackUrl = statusCallbackUrl;
        }

        [JsonPropertyName("method")]
        public MethodEnum Method { get; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; }

        [JsonPropertyName("provider_method_parameters")]
        public ActivatePayPalPPCPParameters ProviderMethodParameters { get; }

        [JsonPropertyName("status_callback_url")]
        public Uri? StatusCallbackUrl { get; }
    }
}
