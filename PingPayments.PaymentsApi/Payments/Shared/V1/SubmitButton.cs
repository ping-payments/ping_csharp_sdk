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

        /// <summary>
        /// CSS-compatible font-size value
        /// </summary>
        [JsonPropertyName("font_size")]
        public string FontSize { get; set; }

        /// <summary>
        /// CSS-compatible font-weight valueh
        /// </summary>
        [JsonPropertyName("font_weight")]
        public string FontWeight { get; set; }

        /// <summary>
        /// CSS-compatible height value
        /// </summary>
        [JsonPropertyName("height")]
        public string Height { get; set; }

        /// <summary>
        /// CSS-compatible width value
        /// </summary>
        [JsonPropertyName("width")]
        public string Width { get; set; }

        /// <summary>
        /// CSS-compatible line-height value
        /// </summary>
        [JsonPropertyName("line_height")]
        public string LineHeight { get; set; }

    }

}
