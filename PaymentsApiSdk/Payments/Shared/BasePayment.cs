using PingPayments.PaymentsApi.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared
{
    public abstract record BasePayment : EmptySuccesfulResponseBody
    {
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        [JsonPropertyName("order_items")]
        public OrderItem[] OrderItems { get; set; }

        [JsonPropertyName("total_amount")]
        public int TotalAmount {  get; set;}

        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }
    }
}
