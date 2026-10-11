using PingPayments.Shared.Enums;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivateQuickpayRequest
    {
        private ActivateQuickpayRequest(MethodEnum method, ActivateQuickpayParameters providerMethodParameters, Uri? statusCallbackUrl)
        {
            Method = method;
            Provider = ProviderEnum.quickpay;
            ProviderMethodParameters = providerMethodParameters;
            StatusCallbackUrl = statusCallbackUrl;
        }

        public static ActivateQuickpayRequest Card(ActivateQuickpayParameters parameters, Uri? statusCallbackUrl = null) =>
            new(MethodEnum.card, parameters, statusCallbackUrl);

        public static ActivateQuickpayRequest ApplePay(ActivateQuickpayParameters parameters, Uri? statusCallbackUrl = null) =>
            new(MethodEnum.apple_pay, parameters, statusCallbackUrl);

        public static ActivateQuickpayRequest GooglePay(ActivateQuickpayParameters parameters, Uri? statusCallbackUrl = null) =>
            new(MethodEnum.google_pay, parameters, statusCallbackUrl);

        [JsonPropertyName("method")]
        public MethodEnum Method { get; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; }

        [JsonPropertyName("provider_method_parameters")]
        public ActivateQuickpayParameters ProviderMethodParameters { get; }

        [JsonPropertyName("status_callback_url")]
        public Uri? StatusCallbackUrl { get; }
    }
}
