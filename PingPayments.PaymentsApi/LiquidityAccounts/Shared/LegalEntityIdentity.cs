using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.LiquidityAccounts.Shared
{
    /// <summary>
    /// Legal identity of the account holder
    /// </summary>
    public record LegalEntityIdentity
    {
        public LegalEntityIdentity(LegalEntityCountryEnum country, string identifier, LegalEntityTypeEnum type)
        {
            Country = country;
            Identifier = identifier;
            Type = type;
        }

        public LegalEntityIdentity()
        {

        }

        /// <summary>
        /// Country of the legal entity
        /// </summary>
        [JsonPropertyName("country")]
        public LegalEntityCountryEnum Country { get; set; } = LegalEntityCountryEnum.SE;

        /// <summary>
        /// Unique identifier without formatting (e.g., personal identification number (YYMMDDXXXX), organization number (10 digits))
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = "";
        /// <summary>
        /// Type of the legal entity (e.g., 'person', 'organization')
        /// </summary>
        [JsonPropertyName("type")]
        public LegalEntityTypeEnum Type { get; set; } = LegalEntityTypeEnum.person;
    }
}
