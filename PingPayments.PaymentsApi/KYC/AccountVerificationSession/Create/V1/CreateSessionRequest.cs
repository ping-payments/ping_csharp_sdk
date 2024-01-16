using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1
{
    public record CreateSessionRequest : AccountVerificationSessionBase
    {
        /// <summary>
        /// Options for the verification session
        /// </summary>
        [JsonPropertyName("session_options")]
        public SessionOptions? Options { get; set; }
    }
}
