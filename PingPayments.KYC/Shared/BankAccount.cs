using System.Text.Json.Serialization;

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
    }
}
