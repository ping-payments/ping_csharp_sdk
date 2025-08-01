using System;
using System.Text.Json.Serialization;
using PingPayments.PaymentsApi.DepositBankAccount.Shared.Transfer;
using PingPayments.Shared;

namespace PingPayments.PaymentsApi.DepositBankAccount.ListBankTransfer.Response.V1
{
    public record BankTransfer
    {
        [JsonPropertyName("data")]
        public BankTransferData[] Data { get; set; } = Array.Empty<BankTransferData>();

        [JsonPropertyName("_links")]
        public PaginationLinks? PaginationLinks { get; set; }
    }
}
