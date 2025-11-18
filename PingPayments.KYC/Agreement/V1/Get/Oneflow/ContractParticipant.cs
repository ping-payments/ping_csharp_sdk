using PingPayments.KYC.Agreement.V1.Create.Oneflow;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get.Oneflow
{
    public class ContractParticipant
    {
        /// <summary>
        /// Participant id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Two letter ISO 3166-2 country code
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// The method that the participant should receive the agreement once published
        /// </summary>
        [JsonPropertyName("delivery_channel")]
        public DeliveryChannelEnum? DeliveryChannel { get; set; } = null;

        /// <summary>
        /// Delivery status
        /// </summary>
        [JsonPropertyName("delivery_status")]
        public DeliveryStatusEnum DeliveryStatus { get; set; }

        /// <summary>
        /// Participant email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Participant identity
        /// </summary>
        [JsonPropertyName("identity")]
        public string Identity { get; set; }

        /// <summary>
        /// Participant name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Is this participant an organizer
        /// </summary>
        [JsonPropertyName("organizer")]
        public bool Organizer { get; set; }

        /// <summary>
        /// Participant phone number
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The method that the participant should use to sign the agreement. 
        /// In sandbox the only available option is standard_esign
        /// </summary>
        [JsonPropertyName("sign_method")]
        public SignMethodEnum SignMethod { get; set; }

        /// <summary>
        /// Current sign state
        /// </summary>
        [JsonPropertyName("sign_state")]
        public ContractSignedStateEnum SignState { get; set; }

        /// <summary>
        /// Timestamp when SignState was updated
        /// </summary>
        [JsonPropertyName("sign_state_updated_at")]
        public DateTimeOffset? SignStateUpdatedAt { get; set; }

        /// <summary>
        /// Is this participant a signatory
        /// </summary>
        [JsonPropertyName("signatory")]
        public bool? Signatory { get; set; }

        /// <summary>
        /// Participant title (like chairman, CEO etc.)
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Two Step Authentication Method
        /// </summary>
        [JsonPropertyName("two_step_authentication_method")]
        public TwoStepAuthenticationMethodEnum? TwoStepAuthenticationMethod { get; set; } = null;

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
