using PingPayments.PaymentsApi.Payments.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Initiate.Request
{
    public record InitiatePaymentRequest : BasePayment
    {
        public InitiatePaymentRequest
        (
            CurrencyEnum currency, 
            int totalAmount, 
            OrderItem[] orderItems,
            ProviderEnum provider,
            MethodEnum method, 
            ProviderMethodParameters providerMethodParameters, 
            Uri statusCallbackUrl,
            IDictionary<string, dynamic> metadata
        )
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
