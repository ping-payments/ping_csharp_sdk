using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class OneflowPerson : OneflowParty
    {
        /// <summary>
        /// If the person can edit the agreement information
        /// </summary>
        [JsonPropertyName("editor")]
        public bool? Editor { get; set; }

        /// <summary>
        /// Email used to deliver the agreement
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number used to deliver the agreement
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Sign method
        /// </summary>
        [JsonPropertyName("sign_method")]
        public OneflowSignMethod SignMethod { get; set; }

        /// <summary>
        /// If the person can sign the agreement
        /// </summary>
        /// <value>If the person can sign the agreement</value
        [JsonPropertyName("signatory")]
        public bool? Signatory { get; set; }

        /// <summary>
        /// The type can only be person
        /// </summary>
        /// <value>The type can only be person</value>
        [JsonPropertyName("type")]
        public OneflowPartyType Type => OneflowPartyType.person;
    }
}
