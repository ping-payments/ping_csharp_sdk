using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record Distribution
    {
        /// <summary>
        /// ISO 9362 Business Identifier Code
        /// </summary>
        [JsonPropertyName("email_options")]
        public EmailOptions EmailOptions { get; set; }

        /// <summary>
        /// Bank account number (IBAN)
        /// </summary>
        [JsonPropertyName("sms_options")]
        public SmsOptions SmsOptions { get; set; }
    }
}
