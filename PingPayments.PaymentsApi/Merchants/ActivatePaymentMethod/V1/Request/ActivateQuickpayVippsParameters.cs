using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request
{
    public record ActivateQuickpayVippsParameters
    {
        private static readonly byte[] PngHeader = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        /// <param name="logo">PNG logo, at least 100 x 100 px and at most 1000 px on the longest side.</param>
        public ActivateQuickpayVippsParameters(string email, byte[] logo, string logoFileName, string? addressLine = null, string? city = null, string? postalCode = null)
        {
            if (!IsPng(logo))
                throw new ArgumentException("Logo must be a PNG file.", nameof(logo));

            Email = email;
            Logo = logo;
            LogoFileName = logoFileName;
            AddressLine = addressLine;
            City = city;
            PostalCode = postalCode;
        }

        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("logo")]
        public byte[] Logo { get; }

        public string LogoFileName { get; }

        [JsonPropertyName("address_line")]
        public string? AddressLine { get; }

        [JsonPropertyName("city")]
        public string? City { get; }

        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; }

        private static bool IsPng(byte[] logo)
        {
            if (logo == null || logo.Length < PngHeader.Length)
                return false;

            for (var i = 0; i < PngHeader.Length; i++)
            {
                if (logo[i] != PngHeader[i])
                    return false;
            }

            return true;
        }
    }
}
