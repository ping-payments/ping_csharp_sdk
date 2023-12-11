using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record PayerAddress
    {
        public PayerAddress(string? city = null, string? country = null, string? county = null, string? postalCode = null, string? street = null)
        {
            City = city;
            Country = country;
            County = county;
            PostalCode = postalCode;
            Street = street;
        }
        /// <summary>
        /// City of residence
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Two letter ISO 3166-2 country code
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// County of residence
        /// </summary>
        [JsonPropertyName("county")]
        public string? County { get; set; }

        /// <summary>
        /// Zip code of residence
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Street name and number of residence
        /// </summary>
        [JsonPropertyName("street")]
        public string? Street { get; set; }

    }
}
