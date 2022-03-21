using PaymentsApiSdk.Payments.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.Initiate.Request
{
    public record InitiatePaymentRequest : BasePayment
    {
        public InitiatePaymentRequest(CurrencyEnum currency, int totalAmount, IDictionary<string, dynamic> metadata, OrderItem[] orderItems, MethodEnum method, ProviderEnum provider, ProviderMethodParameters providerMethodParameters, Uri statusCallbackUrl)
        {
            Currency = currency;
            TotalAmount = totalAmount;
            Metadata = metadata;
            OrderItems = orderItems;
            Method = method;
            Provider = provider;
            ProviderMethodParameters = providerMethodParameters;
            StatusCallbackUrl = statusCallbackUrl;
        }

        [JsonPropertyName("provider_method_parameters")]
        public ProviderMethodParameters ProviderMethodParameters { get; set; }

        [JsonPropertyName("status_callback_url")]
        public Uri StatusCallbackUrl { get; set;}        
    }
}
