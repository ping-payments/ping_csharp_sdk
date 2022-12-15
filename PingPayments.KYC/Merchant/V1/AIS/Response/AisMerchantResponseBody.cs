using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.AIS.Response
{
    public record AisMerchantResponseBody : EmptySuccessfulResponseBody
    {


        /// <summary>
        /// URL for merchant AIS
        /// </summary>
        [JsonPropertyName("ais_url")]
        public Uri? Url { get; set; }

        /// <summary>
        /// Verification ID
        /// </summary>
        [JsonPropertyName("verification_id")]
        public string? VerificationId { get; set; }

        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string? MerchantId { get; set; }

        /// <summary>
        /// A message that states the entity was already registered.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

    }
}
