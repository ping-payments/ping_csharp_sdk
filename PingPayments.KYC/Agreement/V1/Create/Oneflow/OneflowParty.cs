using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class OneflowParty
    {
        /// <summary>
        /// The country code of the party
        /// </summary>
        [JsonPropertyName("country")]
        public OneflowCountryCode Country { get; set; }

        /// <summary>
        /// Identity of the party
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Party name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
