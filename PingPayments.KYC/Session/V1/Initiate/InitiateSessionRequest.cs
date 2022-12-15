using PingPayments.KYC.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Session.V1.Initiate
{
    public record InitiateSessionRequest
    (
        string Email,
        string Phone,
        string PsuId,
        Redirects? Redirects = null,
        Style? Styles = null
        )
    {
        /// <summary>
        /// Email of the one to perform the KYC
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = Email;

        /// <summary>
        /// Phone number of the one to perform the KYC
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = Phone;

        /// <summary>
        /// Either a social security number or a organization number
        /// </summary>
        [JsonPropertyName("psu_id")]
        public string PsuId { get; set; } = PsuId;

        /// <summary>
        /// URL redirections 
        /// </summary>
        [JsonPropertyName("redirects")]
        public Redirects? Redirects { get; set; } = Redirects;

        /// <summary>
        /// Style for for the KYC session layout 
        /// </summary>
        [JsonPropertyName("styles")]
        public Style? Styles { get; set; } = Styles;
    }
}
