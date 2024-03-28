using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.Shared.Transfer
{
    public record PaginationLinkHref
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
