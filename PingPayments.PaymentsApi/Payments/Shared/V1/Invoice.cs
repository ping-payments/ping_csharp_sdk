using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Invoice
    {
        /// <summary>
        /// Type of finance product. 1: 14 days, 6: three months, 7: six months, 8: twelve months
        /// </summary>
        [JsonPropertyName("invoice_type")]
        public int Type { get; set; }

        /// <summary>
        /// Payer national ID number 
        /// </summary>
        [JsonPropertyName("personal_number")]
        public string PersonalNumber { get; set; }

        /// <summary>
        /// Empty, SE, DK, NO, FI, SUO, DE, AT, UK, CH, NL, IE, FR, IT, ES or PL 
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// IP address of the device that the payment is being made from
        /// </summary>
        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Email of payer
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
