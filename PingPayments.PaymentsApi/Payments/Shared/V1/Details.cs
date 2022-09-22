using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Details
    {
        /// <summary>
        /// Data given by payment provider "as is ". This depends on both the "provider" and "method" fields of the Payment.
        /// </summary>
        [JsonPropertyName("provider_data")]
        public IDictionary<string, dynamic>? ProviderData { get; set; }
    }
}

