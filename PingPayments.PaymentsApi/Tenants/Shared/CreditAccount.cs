using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Tenants.Shared
{
    public record CreditAccount
    {
        [JsonPropertyName("credit")]
        public IEnumerable<Credit> Credit { get; set; }
    }
}
