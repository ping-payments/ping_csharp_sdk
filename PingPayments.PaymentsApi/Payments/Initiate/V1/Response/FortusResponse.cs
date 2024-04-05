using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record FortusResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("bankid")]
        public BankId BankId { get; set; }

    }
}
