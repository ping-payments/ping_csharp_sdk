using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PingDepositResponse
    {
        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("deposit_account")]
        public DepositAccount DepositAccount { get; set; }
    }
}
