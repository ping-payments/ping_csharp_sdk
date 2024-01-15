using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared;
using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1
{
    public record GetSessionResponseBody : AccountVerificationSessionBase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("bank_account")]
        public VerificationSessionBankAccountExtension? BankAccount { get; set; }

        [JsonPropertyName("status_history")]
        public IEnumerable<SessionStatusHistory> StatusHistory { get; set; }

        [JsonPropertyName("url")]
        public string? SessionUrl { get; set; }

    }
}
