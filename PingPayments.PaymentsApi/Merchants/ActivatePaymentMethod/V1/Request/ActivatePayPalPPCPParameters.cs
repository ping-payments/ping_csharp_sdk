using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivatePayPalPPCPParameters
    {
        public ActivatePayPalPPCPParameters(string email, Uri redirectUrl)
        {
            Email = email;
            RedirectUrl = redirectUrl;
        }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("redirect_url")]
        public Uri RedirectUrl { get; set; }
    }
}
