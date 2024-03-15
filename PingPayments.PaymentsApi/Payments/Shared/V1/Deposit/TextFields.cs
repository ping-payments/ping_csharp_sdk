using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record TextFields
    {

        /// <summary>
        /// Headline for the invoice
        /// </summary>
        [JsonPropertyName("headline")]
        public string Headline { get; set; }

        /// <summary>
        /// Key value pair will be placed under the headline
        /// </summary>
        [JsonPropertyName("sub_texts")]
        public IDictionary<string, string>? SubText { get; set; }
    }
}
