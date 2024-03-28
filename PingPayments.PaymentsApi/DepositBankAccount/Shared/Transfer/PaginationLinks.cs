using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.Shared.Transfer
{
    public record PaginationLinks
    {
        [JsonPropertyName("current")]
        public PaginationLinkHref? Current { get; set; }

        [JsonPropertyName("first")]
        public PaginationLinkHref? First { get; set; }

        [JsonPropertyName("next")]
        public PaginationLinkHref Next { get; set; }

        [JsonPropertyName("previous")]
        public PaginationLinkHref Previous { get; set; }
    }

}