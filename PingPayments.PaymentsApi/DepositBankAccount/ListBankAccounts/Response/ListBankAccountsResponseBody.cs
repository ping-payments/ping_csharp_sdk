using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.List.Response.V1
{
    public record ListBankAccountsResponseBody : GuidResponseBody
    {
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("bankgiro_number")]
        public string BankgiroNumber { get; set; }

        [JsonPropertyName("bic")]
        public string BIC { get; set; }

        [JsonPropertyName("clearing_number")]
        public string ClearingNumber { get; set; }

        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }

        [JsonPropertyName("iban")]
        public string IBAN { get; set; }
    }

}
