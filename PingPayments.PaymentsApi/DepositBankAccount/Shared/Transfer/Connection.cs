using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.DepositBankAccount.Shared.Transfer
{
    public record Connection
    {
        [JsonPropertyName("connected_at")]
        public string ConnectedAt { get; set; }

        [JsonPropertyName("connected_by")]
        public string ConnectedBy { get; set; }

        [JsonPropertyName("manually_connected")]
        public bool ManuallyConnected { get; set; }

        [JsonPropertyName("payment_id")]
        public string PaymentId { get; set; }
    }

}