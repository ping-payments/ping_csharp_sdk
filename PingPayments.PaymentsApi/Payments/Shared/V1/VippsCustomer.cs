using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record VippsCustomer
    {
        public VippsCustomer(string? email = null, string? firstName = null, string? lastName = null, string? phoneNumber = null, string? city = null, string? postalCode = null, string? streetAddress = null, string? country = null)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            City = city;
            PostalCode = postalCode;
            Street = streetAddress;
            Country = country;
        }
        public VippsCustomer()
        {

        }

        /// <summary>
        /// First name of customer
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name of customer
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// Phone number of customer
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Email of payer
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

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
        [JsonPropertyName("street_address")]
        public string? Street { get; set; }
    }
}
