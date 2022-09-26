using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Tenants.Shared
{
    public record Credit
    {
        [JsonPropertyName("balance")]
        public int Balance { get; set; }


        [JsonPropertyName("currency")]
        public CurrencyEnum Currency { get; set; }
    }
}

