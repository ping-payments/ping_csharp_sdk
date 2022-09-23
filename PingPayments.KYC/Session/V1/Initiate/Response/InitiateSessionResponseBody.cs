using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Session.V1.Initiate.Response
{
    public record InitiateSessionResponseBody : EmptySuccesfulResponseBody
    {
        /// <summary>
        /// Url for Validation session
        /// </summary>
        [JsonPropertyName("validation_url")]
        public Uri ValidationUrl { get; set; }

        /// <summary>
        /// Id of the verification
        /// </summary>
        [JsonPropertyName("verification_id")]
        public string VerificationId { get; set; }
    }
}
