using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared
{
    public record SessionOptions
    {
        /// <summary>
        /// The date from which transactions should be fetched. Format: YYYY-MM-DD
        /// </summary>
        [JsonPropertyName("account_transaction_history_from_date")]
        public string AccountTransactionHistoryFromDate { get; set; }

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
        /// The URL that the user will be redirected to if they try and go back to the session after it has terminated
        /// </summary>
        [JsonPropertyName("session_down_url")]
        public string? SessionDownUrl { get; set; }

        /// <summary>
        /// Whether the session UI will be iframed
        /// </summary>
        [JsonPropertyName("iframed")]
        public bool IsIFramed { get; set; } = false;

        /// <summary>
        /// Locale to use for localizing the session UI
        /// Pattern: [a-z]{2}-[A-Z]{2} (e.g. en-US, sv-SE). Default: sv-SE
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
