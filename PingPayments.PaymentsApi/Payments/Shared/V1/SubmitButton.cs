using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record SubmitButton
    {
        /// <summary>
        /// CSS-compatible hexadecimal color value
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }

}
