using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public abstract record BasePayment : EmptySuccessfulResponseBody
    {
        /// <summary>
        /// Currency used for payment
        /// </summary>
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }

        /// <summary>
        /// Custom metadata for payment
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }


        [JsonPropertyName("order_items")]
        public IEnumerable<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Total amount in minor currency unit, i ex Swedish Ören
        /// Must be the same as the total sum of <see cref="OrderItem.Amount"/>
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// The provider used for the payment, i ex <see cref="ProviderEnum.swish"/>
        /// </summary>
        [JsonPropertyName("provider")]
        public ProviderEnum Provider { get; set; }

        /// <summary>
        /// The method used for the payment, i ex <see cref="MethodEnum.mobile"/>
        /// These are combined with the <see cref="Provider"/>
        /// </summary>
        [JsonPropertyName("method")]
        public MethodEnum Method { get; set; }

        /// <summary>
        /// Information regarding the payer
        /// </summary>
        [JsonPropertyName("payer")]
        public Payer? Payer { get; set; }

    }
}
