using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record Redirects
    {
        /// <summary>
        /// Url that the user will be redirected to upon cancellation
        /// </summary>
        [JsonPropertyName("cancel_url")]
        public Uri? CancelUrl { get; set; }

        /// <summary>
        /// Url that the user will be redirected to after successful completion of the form
        /// </summary>
        [JsonPropertyName("success_url")]
        public Uri? SuccessUrl { get; set; }


        /// <summary>
        /// Url that the user will be redirected to if the session timesout
        /// </summary>
        [JsonPropertyName("timeout_url")]
        public Uri? TimeoutUrl { get; set; }
    }
}
