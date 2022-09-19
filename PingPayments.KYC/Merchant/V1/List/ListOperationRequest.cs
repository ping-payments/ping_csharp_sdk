using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.List
{
    public record ListOperationRequest
    {

        /// <summary>
        /// Number of elements per page
        /// </summary>
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }


        /// <summary>
        /// Number of the page
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }

        /// <summary>
        /// Type of merchants
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Get by Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; }

    }
}
