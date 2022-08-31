using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record InitiatePaymentRequest : BasePayment
    {
        public InitiatePaymentRequest
        (
            CurrencyEnum currency, 
            int totalAmount, 
            IEnumerable<OrderItem> orderItems,
            ProviderEnum provider,
            MethodEnum method, 
            ProviderMethodParameters providerMethodParameters, 
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        )
        {
            Currency = currency;
            TotalAmount = totalAmount;
            Metadata = metadata ?? new Dictionary<string, dynamic>();
            OrderItems = orderItems;
            Method = method;
            Provider = provider;
            ProviderMethodParameters = providerMethodParameters;
            StatusCallbackUrl = statusCallbackUrl;
        }

        /// <summary>
        /// Extra parameters for the combination of <see cref="ProviderEnum"/> and <see cref="MethodEnum"/>
        /// </summary>
        [JsonPropertyName("provider_method_parameters")]
        public ProviderMethodParameters ProviderMethodParameters { get; set; }

        /// <summary>
        /// Callback where the Tenant will get payment updates through HTTP
        /// </summary>
        [JsonPropertyName("status_callback_url")]
        public Uri StatusCallbackUrl { get; set;}        
    }
}
