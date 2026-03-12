using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record KlarnaRedirectUrls
    {
        public KlarnaRedirectUrls(Uri back, Uri cancel, Uri error, Uri failure, Uri success)
        {
            Back = back;
            Cancel = cancel;
            Error = error;
            Failure = failure;
            Success = success;
        }

        public KlarnaRedirectUrls()
        {

        }

        /// <summary>
        /// URL to redirect to when user goes back (clicks/taps the X button)
        /// </summary>
        [JsonPropertyName("back")]
        public Uri Back { get; set; }

        /// <summary>
        /// URL to redirect to when payment is cancelled
        /// </summary>
        [JsonPropertyName("cancel")]
        public Uri Cancel { get; set; }

        /// <summary>
        /// URL to redirect to when an error occurs
        /// </summary>
        [JsonPropertyName("error")]
        public Uri Error { get; set; }

        /// <summary>
        /// URL to redirect to when payment fails
        /// </summary>
        [JsonPropertyName("failure")]
        public Uri Failure { get; set; }

        /// <summary>
        /// URL to redirect to after successful payment
        /// </summary>
        [JsonPropertyName("success")]
        public Uri Success { get; set; }
    }


}
