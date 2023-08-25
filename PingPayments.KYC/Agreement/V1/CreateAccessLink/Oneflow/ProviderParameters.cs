using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink.Oneflow
{
    public abstract class ProviderParameters : CreateAccessLinkProviderParameters
    {
        /// <summary>
        /// Id of the participant for which the link should be created
        /// </summary>
        [JsonPropertyName("participant_id")]
        public string ParticipantId { get; set; }
    }
}
