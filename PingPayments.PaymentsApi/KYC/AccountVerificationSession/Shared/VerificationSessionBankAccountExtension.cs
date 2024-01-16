using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared
{
    public record VerificationSessionBankAccountExtension : Payments.Shared.V1.BankAccount
    {
        [JsonPropertyName("account_number")]
        public string? AccountNumber { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }
    }
}
