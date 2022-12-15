using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record Style
    {

        /// <summary>
        /// The background color of the page, given in hex color codes.
        /// </summary>
        [JsonPropertyName("background_color")]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// The background color for the form, given in hex color codes.
        /// </summary>
        [JsonPropertyName("form_background_color")]
        public string? FormBackgroundColor { get; set; }

        /// <summary>
        /// The primary color, buttons, progressbar and accents will be this color, given in hex color codes.
        /// </summary>
        [JsonPropertyName("primary")]
        public string? Primary { get; set; }

    }
}
