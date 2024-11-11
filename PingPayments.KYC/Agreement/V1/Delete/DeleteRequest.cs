using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Delete
{
    public record DeleteRequest
    {
        /// <summary>
        /// Id of the agreement to be deleted
        /// </summary>
        public Guid AgreementId { get; set; }

        [JsonPropertyName("deleted_by")]
        public string DeletedBy { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
