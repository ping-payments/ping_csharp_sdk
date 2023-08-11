using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class Organization : Party
    {
        /// <summary>
        /// List of sub parties
        /// </summary>
        /// <value>A list of sub parties</value>
        [JsonPropertyName("sub_parties")]
        public List<Subparty> SubParties { get; set; }

        /// <summary>
        /// Type can only be organization
        /// </summary>
        /// <value>The type can only be organization</value>
        [JsonPropertyName("type")]
        public PartyTypeEnum Type => PartyTypeEnum.organization;
    }
}
