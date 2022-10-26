using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record DepositAccount
    {
        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        [JsonPropertyName("bankgiro_number")]
        public string BankgiroNumber { get; set; }
    }
}
