using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record OrganizationData
    {
        /// <summary>
        /// Organization identity number
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

    }
}
