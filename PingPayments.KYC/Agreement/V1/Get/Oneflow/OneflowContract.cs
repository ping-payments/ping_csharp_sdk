using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get.Oneflow
{
    public class OneflowContract : AgreementProviderData
    {
        /// <summary>
        /// Gets or Sets DataFields
        /// </summary>
        [JsonPropertyName("data_fields")]
        public List<OneflowContractDataField> DataFields { get; set; }

        /// <summary>
        /// Gets or Sets Participants
        /// </summary>
        [JsonPropertyName("participants")]
        public List<OneflowContractParticipant> Participants { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [JsonPropertyName("state")]
        public OneflowContractState State { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneflowContract {\n");
            sb.Append("  DataFields: ").Append(DataFields).Append("\n");
            sb.Append("  Participants: ").Append(Participants).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
