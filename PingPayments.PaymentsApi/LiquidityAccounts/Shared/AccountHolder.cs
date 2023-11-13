using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Shared
{
    /// <summary>
    /// Represents the account holder details
    /// </summary>
    public record AccountHolder
    {
        public AccountHolder(string name, LegalEntityIdentity identity)
        {
            Name = name;
            Identity = identity;
        }

        public AccountHolder()
        {

        }

        /// <summary>
        /// Legal name of the account holder
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Legal entity identity information
        /// </summary>
        [JsonPropertyName("identity")]
        public LegalEntityIdentity Identity { get; set; } = new();
    }
}
