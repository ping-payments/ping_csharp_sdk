using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared
{
    public record SessionOptions
    {
        /// <summary>
        /// The URL that the user will be redirected to if the use cancels the session
        /// </summary>
        [JsonPropertyName("cancel_url")]
        public string? CancelUrl { get; set; }

        /// <summary>
        /// The URL that the user will be redirected to if an error occurs
        /// </summary>
        [JsonPropertyName("error_url")]
        public string? ErrorUrl { get; set; }

        /// <summary>
        /// The URL that the user will be redirected to after the session has succeeded
        /// </summary>
        [JsonPropertyName("success_url")]
        public string? SuccessUrl { get; set; }

        /// <summary>
        /// The URL that the user will be redirected to if the session times out
        /// </summary>
        [JsonPropertyName("timeout_url")]
        public string? TimeoutUrl { get; set; }

        /// <summary>
        /// Whether the session UI will be iframed
        /// </summary>
        [JsonPropertyName("iframed")]
        public bool IsIFramed { get; set; } = false;

        /// <summary>
        /// Locale to use for localizing the session UI
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// The URL that the user will be redirected to if they choose the 'other bank' options in the bank list
        /// </summary>
        [JsonPropertyName("manual_add_bank_url")]
        public string? ManualAddBankUrl { get; set; }

        /// <summary>
        /// Styling options
        /// </summary>
        [JsonPropertyName("styling")]
        public Style? Style { get; set; }
    }
}
