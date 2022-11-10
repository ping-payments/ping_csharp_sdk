using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record SmsOptions
    {
        /// <summary>
        /// Distribute sms or not
        /// </summary>
        [JsonPropertyName("distribute")]
        public bool Distribute { get; set; }

        /// <summary>
        /// Message to be sent. Url will replace $url in the message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Originator of the sms
        /// </summary>
        [JsonPropertyName("originator")]
        public string Originator { get; set; }

    }
}
