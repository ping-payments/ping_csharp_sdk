using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Tenants.Shared;
using PingPayments.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Tenants.Get.V1
{
    public record TenantResponseBody : GuidResponseBody
    {
        [JsonPropertyName("accounts")]
        public CreditAccount? CreditAccounts { get; set; }


        [JsonPropertyName("callback_signing_key")]
        public string? SigningKey { get; set; }


        [JsonPropertyName("credit_account_top_up_callback_url")]
        public string? CreditAccountTopUpCallbackUrl { get; set; }


        [JsonPropertyName("disbursement_callback_url")]
        public string? DisbursementCallbackUrl { get; set; }


        [JsonPropertyName("merchant_status_callback_url")]
        public string? MerchantStatusCallbackUrl { get; set; }


        [JsonPropertyName("name")]
        public string? Name { get; set; }


        [JsonPropertyName("organization")]
        public Organization? Organization { get; set; }


        [JsonPropertyName("payment_provider_methods")]
        public IEnumerable<ProviderMethodBase>? PaymentProviderMethods { get; set; }


    }
}
