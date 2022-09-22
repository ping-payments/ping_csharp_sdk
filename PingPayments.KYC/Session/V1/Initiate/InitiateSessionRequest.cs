using PingPayments.KYC.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Session.V1.Initiate
{
    public record InitiateSessionRequest
    (
        string Email,
        string Phone,
        string PsuId,
        Redirects? Redirects = null,
        Styles? Styles = null,
        string? TenantId = null)
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
        ///TODO
        /// </summary>
        [JsonPropertyName("redirects")]
        public Redirects? Redirects { get; set; } = Redirects;

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("styles")]
        public Styles? Styles { get; set; } = Styles;

        /// <summary>
        /// Id of the tenant that the one to perform the KYC belongs to
        /// </summary>
        [JsonPropertyName("tenant_id")]
        public string? TenantId { get; set; } = TenantId;
    }
}
