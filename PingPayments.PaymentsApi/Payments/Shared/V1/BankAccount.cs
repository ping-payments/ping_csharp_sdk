using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record BankAccount
    {
        /// <summary>
        /// International Bank Account Number
        /// </summary>
        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        /// <summary>
        /// Basic Bank Account Number
        /// </summary>
        [JsonPropertyName("bban")]
        public string Bban { get; set; }

        /// <summary>
        /// Bank Identifier Code
        /// </summary>
        [JsonPropertyName("bic")]
        public string Bic { get; set; }

        /// <summary>
        /// Bankgiro number of the bank account
        /// </summary>
        [JsonPropertyName("bankgiro_number")]
        public string BankgiroNumber { get; set; }
    }
}
