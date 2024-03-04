using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1.Deposit;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PingDepositResponse
    {
        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; }

        [JsonPropertyName("invoice")]
        public InvoiceUrls Invoice { get; set; }

        [JsonPropertyName("deposit_account")]
        [Obsolete("Replaced with BankAccount.")]
        public BankAccount DepositAccount { get; set; }
    }
}
