using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record DepositAccount
    {
        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        [JsonPropertyName("bban")]
        public string bban { get; set; }

        [JsonPropertyName("bic")]
        public string bic { get; set; }

        [JsonPropertyName("bankgiro_number")]
        public string BankgiroNumber { get; set; }
    }
}
