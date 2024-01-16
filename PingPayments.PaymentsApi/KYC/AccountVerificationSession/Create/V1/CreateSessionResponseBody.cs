using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1
{
    public record CreateSessionResponseBody : EmptySuccessfulResponseBody
    {
        /// <summary>
        /// ID of the created session
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Url for Validation session
        /// </summary>
        [JsonPropertyName("url")]
        public string SessionVerificationUrl { get; set; }
    }
}
