using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record Invoice
    {
        /// <summary>
        /// Locale of the invoice.
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Invoice text fields
        /// </summary>
        [JsonPropertyName("text_fields")]
        public TextFields TextFields { get; set; }

        /// <summary>
        /// Supplier information. Default: {}
        /// </summary>
        [JsonPropertyName("supplier")]
        public Supplier? Supplier { get; set; }

        /// <summary>
        /// Customer information
        /// </summary>
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Invoice rows
        /// </summary>
        [JsonPropertyName("rows")]
        public Row[] Rows { get; set; }


    }
}
