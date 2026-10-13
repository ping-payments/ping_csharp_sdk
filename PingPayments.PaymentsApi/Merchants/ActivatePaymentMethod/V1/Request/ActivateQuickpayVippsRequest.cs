using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivateQuickpayVippsRequest
    {
        public ActivateQuickpayVippsRequest(ActivateQuickpayVippsParameters providerMethodParameters, Uri? statusCallbackUrl = null)
        {
            Method = MethodEnum.vipps;
            Provider = ProviderEnum.quickpay;
            ProviderMethodParameters = providerMethodParameters;
            StatusCallbackUrl = statusCallbackUrl;
        }

        [JsonPropertyName("method")]
        public MethodEnum Method { get; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; }

        [JsonPropertyName("provider_method_parameters")]
        public ActivateQuickpayVippsParameters ProviderMethodParameters { get; }

        [JsonPropertyName("status_callback_url")]
        public Uri? StatusCallbackUrl { get; }
    }
}
