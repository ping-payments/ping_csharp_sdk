using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public abstract class Party
    {
        /// <summary>
        /// Country code of party
        /// </summary>
        [JsonPropertyName("country")]
        public CountryEnum Country { get; set; }

        /// <summary>
        /// Identity of party
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
