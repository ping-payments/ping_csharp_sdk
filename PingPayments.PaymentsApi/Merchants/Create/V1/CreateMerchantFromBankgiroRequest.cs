using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Create.V1
{
    public record CreateMerchantFromBankgiroRequest
    {
        /// <summary>
        /// Tenants name of the merchant
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Swedish bankgiro number with the following pattern: ^\d{7,8}$
        /// </summary>
        [JsonPropertyName("bankgiro_number")]
        public string BankgiroNumber { get; set; }

        /// <summary>
        /// Properties for identifying the legal entity owning the bankgiro account
        /// </summary>
        [JsonPropertyName("identity")]
        public LegalEntityIdentity Identity { get; set; }
    }
}
