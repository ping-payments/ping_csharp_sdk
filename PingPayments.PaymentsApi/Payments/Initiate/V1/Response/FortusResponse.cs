using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record FortusResponse
    {
        [JsonPropertyName("bankid")]
        public BankId? BankId { get; set; }

        [JsonPropertyName("instruction")]
        public string Instruction { get; set; }

    }
}
