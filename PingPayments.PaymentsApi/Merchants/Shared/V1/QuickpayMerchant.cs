using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public record QuickpayMerchant
    {
        /// <summary>
        /// The quickpay merchant id
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; }
    }
}
