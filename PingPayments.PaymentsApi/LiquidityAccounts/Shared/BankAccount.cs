using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Shared
{
    /// <summary>
    /// Bank account details for deposits
    /// </summary>
    public record BankAccount
    {
        public BankAccount(string bankgiroNumber, string bban, string bic, string iban)
        {
            BankgiroNumber = bankgiroNumber;
            Bban = bban;
            Bic = bic;
            Iban = iban;
        }

        public BankAccount()
        {

        }

        /// <summary>
        /// Bankgiro number of the bank account
        /// </summary>
        [JsonPropertyName("bankgiro_number")]
        public string BankgiroNumber { get; set; } = "";

        /// <summary>
        /// Basic Bank Account Number
        /// </summary>
        [JsonPropertyName("bban")]
        public string Bban { get; set; } = "";

        /// <summary>
        /// Bank Identifier Code
        /// </summary>
        [JsonPropertyName("bic")]
        public string Bic { get; set; } = "";

        /// <summary>
        /// International Bank Account Number
        /// </summary>
        [JsonPropertyName("iban")]
        public string Iban { get; set; } = "";
    }
}
