using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.Shared.Transfer
{
    public record RemittanceInformation
    {
        [JsonPropertyName("payer_information")]
        public PayerInformation PayerInformation { get; set; }

        [JsonPropertyName("payment_channel")]
        public string? PaymentChannel { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
    }

}