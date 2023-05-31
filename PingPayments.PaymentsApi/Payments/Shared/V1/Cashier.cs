using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Cashier
    {
        /// <summary>
        /// The amount display
        /// </summary>
        [JsonPropertyName("amount")]
        public Amount? Amount { get; set; }

        /// <summary>
        /// The top most part of the cashier
        /// </summary>
        [JsonPropertyName("header")]
        public Header? Header { get; set; }

        /// <summary>
        /// The bottom part of the cashier
        /// </summary>
        [JsonPropertyName("footer")]
        public Footer? Footer { get; set; }

        /// <summary>
        /// The Container of the cashier
        /// </summary>
        [JsonPropertyName("container")]
        public Container? Container { get; set; }

        /// <summary>
        /// Submit button
        /// </summary>
        [JsonPropertyName("submit_button")]
        public SubmitButton? SubmitButton { get; set; }

        /// <summary>
        /// Font family
        /// </summary>
        [JsonPropertyName("font_family")]
        public string? FontFamily { get; set; }
    }

}
