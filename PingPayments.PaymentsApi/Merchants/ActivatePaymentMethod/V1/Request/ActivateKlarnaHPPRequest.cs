using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivateKlarnaHPPRequest
    {
        public ActivateKlarnaHPPRequest(ActivateKlarnaHPPParameters providerMethodParameters, Uri? statusCallbackUrl = null)
        {
            Method = MethodEnum.hpp;
            Provider = ProviderEnum.klarna;
            ProviderMethodParameters = providerMethodParameters;
            StatusCallbackUrl = statusCallbackUrl;
        }

        [JsonPropertyName("method")]
        public MethodEnum Method { get; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; }

        [JsonPropertyName("provider_method_parameters")]
        public ActivateKlarnaHPPParameters ProviderMethodParameters { get; }

        [JsonPropertyName("status_callback_url")]
        public Uri? StatusCallbackUrl { get; }
    }
}
