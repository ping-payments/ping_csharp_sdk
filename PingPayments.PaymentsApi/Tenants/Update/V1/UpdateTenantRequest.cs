using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Tenants.Update.V1
{

    public record UpdateTenantRequest(
        Uri CreditAccountTopUpCallbackUrl,
        Uri MerchantStatusCallbackUrl,
        Uri? DisbursementCallbackUrl = null)
    {
        /// <summary>
        /// Callback url for credit top-ups
        /// </summary>
        [JsonPropertyName("credit_account_top_up_callback_url")]
        public Uri CreditAccountTopUpCallbackUrl { get; set; } = CreditAccountTopUpCallbackUrl;

        /// <summary>
        /// Callback url for merchant status
        /// </summary>
        [JsonPropertyName("merchant_status_callback_url")]
        public Uri MerchantStatusCallbackUrl { get; set; } = MerchantStatusCallbackUrl;

        /// <summary>
        /// Callback url for disbursements
        /// </summary>
        [JsonPropertyName("disbursement_callback_url")]
        public Uri? DisbursementCallbackUrl { get; set; } = DisbursementCallbackUrl;
    }
}
