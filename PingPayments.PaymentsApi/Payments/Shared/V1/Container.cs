using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Container
    {
        /// <summary>
        /// CSS compatible padding 
        /// </summary>
        [JsonPropertyName("padding")]
        public string? Padding { get; set; }
    }
}
