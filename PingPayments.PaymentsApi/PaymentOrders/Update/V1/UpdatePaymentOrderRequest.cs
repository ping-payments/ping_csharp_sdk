using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentOrders.Update.V1
{

    public record UpdatePaymentOrderRequest(dynamic? SplitParamters = null, Guid? SplitTreeId = null)
    {
        /// <summary>
        /// Parameters used to control parts of the split tree
        /// </summary>
        [JsonPropertyName("split_parameters")]
        public dynamic? SplitParamters { get; set; } = SplitParamters ?? new Dictionary<string, dynamic>();

        /// <summary>
        /// Split tree used for the payment order
        /// </summary>
        [JsonPropertyName("split_tree_id")]
        public Guid? SplitTreeId { get; set; } = SplitTreeId;
    }
}
