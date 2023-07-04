using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class OneflowOrganization : OneflowParty
    {
        /// <summary>
        /// A list of sub parties
        /// </summary>
        /// <value>A list of sub parties</value>
        [JsonPropertyName("sub_parties")]
        public List<OneflowSubparty> SubParties { get; set; }

        /// <summary>
        /// The type can only be organization
        /// </summary>
        /// <value>The type can only be organization</value>
        [JsonPropertyName("type")]
        public OneflowPartyType Type => OneflowPartyType.organization;
    }
}
