using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1
{
    public record CreatePaymentConsentRequest : ProviderMethodBase
    {
        public CreatePaymentConsentRequest
        (
            string flow,
            ProviderEnum provider,
            MethodEnum method,
            ProviderMethodParameters providerMethodParameters,
            Payer? signee = null,
            Uri? statusCallbackUrl = null,
            IDictionary<string, dynamic>? metadata = null
        )
        {
            Flow = flow;
            Provider = provider;
            Method = method;
            ProviderMethodParameters = providerMethodParameters;
            Signee = signee;
            StatusCallbackUrl = statusCallbackUrl;
            Metadata = metadata ?? new Dictionary<string, dynamic>();
        }

        [JsonPropertyName("flow")]
        public string Flow { get; set; }

        [JsonPropertyName("provider_method_parameters")]
        public ProviderMethodParameters ProviderMethodParameters { get; set; }

        [JsonPropertyName("signee")]
        public Payer? Signee { get; set; }

        [JsonPropertyName("status_callback_url")]
        public Uri? StatusCallbackUrl { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }
    }
}
