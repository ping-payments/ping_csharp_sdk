using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Create.V1
{

    public record CreatePaymentOrderRequest(CurrencyEnum Currency, dynamic? SplitParamters = null, Guid? SplitTreeId = null)
    {
        /// <summary>
        /// The currency which will be used in the payment order
        /// </summary>
        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; } = Currency;

        /// <summary>
        /// Parameters used to control parts of the split tree
        /// </summary>
        [JsonPropertyName("split_parameters")]
        public dynamic? SplitParamters { get; set; } = SplitParamters ?? new Dictionary<string, dynamic>();

        /// <summary>
        /// The split tree used for the payment order
        /// </summary>
        [JsonPropertyName("split_tree_id")]
        public Guid? SplitTreeId { get; set; } = SplitTreeId;
    }
}
