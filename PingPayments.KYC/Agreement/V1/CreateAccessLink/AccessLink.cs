using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.CreateAccessLink
{
    public class AccessLink
    {
        /// <summary>
        /// Generated link to the agreement
        /// </summary>
        [JsonPropertyName("link")]
        public string Url { get; set; }
    }
}
