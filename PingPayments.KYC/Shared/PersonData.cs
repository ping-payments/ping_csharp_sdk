using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record PersonData
    {
        /// <summary>
        /// Birthdate
        /// </summary>
        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }

        /// <summary>
        /// Firstname
        /// </summary>
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Person identity number
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Lastname
        /// </summary>
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
    }
}
