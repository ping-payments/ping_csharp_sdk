using PingPayments.PaymentsApi.Merchants.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Create.V1
{
    public record CreateMerchantRequest
    {
        /// <summary>
        /// Tenants name of the merchant
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The merchants underlying organization
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization Organization { get; set; }
    }
}