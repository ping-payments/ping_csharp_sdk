using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record InvoiceUrls
    {
        /// <summary>
        /// Url to display the invoice
        /// </summary>
        [JsonPropertyName("display_url")]
        public string DisplayUrl { get; set; } = "";

        /// <summary>
        /// Url to download the invoice
        /// </summary>
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; } = "";


    }
}
