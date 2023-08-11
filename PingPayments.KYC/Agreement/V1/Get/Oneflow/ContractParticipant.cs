using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get.Oneflow
{
    public class ContractParticipant
    {
        /// <summary>
        /// Gets or Sets Identity
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets SignState
        /// </summary>
        [JsonPropertyName("sign_state")]
        public ContractSignedStateEnum SignState { get; set; }

        /// <summary>
        /// Gets or Sets Signatory
        /// </summary>
        [JsonPropertyName("signatory")]
        public bool? Signatory { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneflowContractParticipant {\n");
            sb.Append("  Identity: ").Append(Identity).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SignState: ").Append(SignState).Append("\n");
            sb.Append("  Signatory: ").Append(Signatory).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

    }
}
