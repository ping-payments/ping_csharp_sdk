using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record Invoice
    {
        /// <summary>
        /// Url to display the invoice
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("text_fields")]
        public TextFields TextFields { get; set; }

        /// <summary>
        /// Supplier information. Default: {}
        /// </summary>
        [JsonPropertyName("supplier")]
        public Supplier? Supplier { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("rows")]
        public Row[] Rows { get; set; }


    }
}
