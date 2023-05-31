using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Footer
    {
        /// <summary>
        /// Whether or not to hide the element
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; } = false;
    }

}
