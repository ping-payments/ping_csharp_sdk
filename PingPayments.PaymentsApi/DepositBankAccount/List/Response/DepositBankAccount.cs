using System;
using System.Text.Json.Serialization;
using PingPayments.PaymentsApi.DepositBankAccount.Shared;

namespace PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1
{
    public record DepositBankAccount
    {
        [JsonPropertyName("data")]
        public DepositBankAccountData[] Data { get; set; } = Array.Empty<DepositBankAccountData>();
    }

}