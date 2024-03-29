﻿using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record BankAccount
    {
        /// <summary>
        /// ISO 9362 Business Identifier Code
        /// </summary>
        [JsonPropertyName("bic")]
        public string Bic { get; set; }

        /// <summary>
        /// Bank account number (IBAN)
        /// </summary>
        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [JsonPropertyName("bban")]
        public string Bban { get; set; }

        /// <summary>
        /// Clearing number
        /// </summary>
        [JsonPropertyName("clearing")]
        public string Clearing { get; set; }

        /// <summary>
        /// Plusgiro number
        /// </summary>
        [JsonPropertyName("plusgiro")]
        public string? Plusgiro { get; set; }

        /// <summary>
        /// Bankgiro number
        /// </summary>
        [JsonPropertyName("bankgiro")]
        public string? Bankgiro { get; set; }

        /// <summary>
        /// Type of currency
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }
    }
}
