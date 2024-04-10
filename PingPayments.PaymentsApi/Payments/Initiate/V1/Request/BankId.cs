using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public record BankId
    {
        /// <summary>
        /// Defines the authentication method based on the device. Use 'same_device' for autostart BankID authentication on the same device, 
        /// and 'other_device' for initiating BankID authentication through an animated QR code when the authentication process occurs on a different device.
        /// </summary>
        [JsonPropertyName("method")]
        public BankIdMethodEnum Method { get; set; }

        /// <summary>
        /// URL to redirect to after BankID authentication when using 'same_device' method 
        /// </summary>
        [JsonPropertyName("redirect_url")]
        public string? RedirectUrl { get; set; }

        /// <summary>
        /// URL to send QR code to. Applicable when using the 'other_device' method
        /// </summary>
        [JsonPropertyName("qr_code_callback_url")]
        public string? QrCodeCallbackUrl { get; set; }

        /// <summary>
        /// Size of QR code in pixels. Default is 300
        /// </summary>
        [JsonPropertyName("qr_code_size")]
        public int? QrCodeSize { get; set; }
    }
}
