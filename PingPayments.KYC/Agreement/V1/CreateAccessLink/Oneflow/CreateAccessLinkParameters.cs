using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink.Oneflow
{
    public class CreateAccessLinkParameters : CreateAccessLinkProviderParameters
    {
        /// <summary>
        /// Id of the participant for which the link should be created
        /// </summary>
        [JsonPropertyName("participant_id")]
        public string ParticipantId { get; set; }
    }
}
