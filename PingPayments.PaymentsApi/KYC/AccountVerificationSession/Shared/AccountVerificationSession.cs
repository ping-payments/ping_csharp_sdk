using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using PingPayments.PaymentsApi.Payments.Initiate.V1.Request;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared
{
    public record AccountVerificationSessionBase
    {
        /// <summary>
        /// Properties for identifying a legal entity
        /// </summary>
        [JsonPropertyName("account_holder")]
        public LegalEntityIdentity AccountHolder { get; set; }

        /// <summary>
        /// Unique Id for a specific merchant
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string? MerchantId { get; set; }

        /// <summary>
        /// Callback for receiving status updates on the Account Verification session 
        /// </summary>
        [JsonPropertyName("status_callback_url")]
        public string? StatusCallbackUrl { get; set; }
    }
}
