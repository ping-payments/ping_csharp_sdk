using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record EmailOptions
    {
        /// <summary>
        /// Distribute email or not
        /// </summary>
        [JsonPropertyName("distribute")]
        public bool Distribute { get; set; }

        /// <summary>
        /// Originator of the email
        /// </summary>
        [JsonPropertyName("originator")]
        public string Originator { get; set; }

    }
}
