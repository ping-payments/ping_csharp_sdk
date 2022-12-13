using PingPayments.KYC.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Get
{
    public record GetKycRequest
    {

        /// <summary>
        /// Number of elements per page
        /// </summary>
        [JsonPropertyName("page_size")]
        public int? PageSize { get; set; }

        /// <summary>
        /// Number of the page
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }


        /// <summary>
        /// Get by Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid? MerchantId { get; set; }
    }
}
