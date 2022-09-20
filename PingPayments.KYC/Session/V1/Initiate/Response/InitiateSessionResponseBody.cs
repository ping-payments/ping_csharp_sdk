using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Session.V1.Initiate.Response
{
    public record InitiateSessionResponseBody : EmptySuccesfulResponseBody
    {
        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("validation_url")]
        public Uri ValidationUrl { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("verification_id")]
        public string VerificationId { get; set; }
    }
}
