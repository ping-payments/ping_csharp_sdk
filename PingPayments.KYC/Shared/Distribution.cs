using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record Distribution
    {
        /// <summary>
        /// Options for email distribution
        /// </summary>
        [JsonPropertyName("email_options")]
        public EmailOptions EmailOptions { get; set; }

        /// <summary>
        /// Options for sms distribution
        /// </summary>
        [JsonPropertyName("sms_options")]
        public SmsOptions SmsOptions { get; set; }
    }
}
