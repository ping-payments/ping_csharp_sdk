using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record KlarnaAddress
    {
        public KlarnaAddress(string? email = null, string? firstName = null, string? lastName = null, string? phoneNumber = null, string? city = null, string? postalCode = null, string? streetAddress = null, string? country = null, string? streetAddress2 = null, string? region = null, string? title = null, string? attention = null, string? organizationName = null)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            City = city;
            PostalCode = postalCode;
            Street = streetAddress;
            Street2 = streetAddress2;
            Country = country;
            Region = region;
            Title = title;
            Attention = attention;
            OrganizationName = organizationName;
        }

        public KlarnaAddress()
        {

        }

        /// <summary>
        /// 'Attn.' (if applicable). Only applicable for B2B customers.
        /// </summary>
        [JsonPropertyName("attention")]
        public string? Attention { get; set; }

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
        /// Email of payer
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// First name of customer
        /// </summary>
        [JsonPropertyName("given_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name of customer
        /// </summary>
        [JsonPropertyName("family_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// Phone number of customer
        /// </summary>
        [JsonPropertyName("organization_name")]
        public string? OrganizationName { get; set; }

        /// <summary>
        /// Phone number of customer
        /// </summary>
        [JsonPropertyName("phone")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Zip code of residence
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Phone number of customer
        /// </summary>
        [JsonPropertyName("region")]
        public string? Region { get; set; }

        /// <summary>
        /// Street name and number of residence
        /// </summary>
        [JsonPropertyName("street_address")]
        public string? Street { get; set; }       
        
        /// <summary>
        /// Customer's street address. Second Line.
        /// </summary>
        [JsonPropertyName("street_address2")]
        public string? Street2 { get; set; }

        /// <summary>
        /// Customer's title. Allowed values per country: 
        /// UK - "Mr", "Ms"; 
        /// DE - "Herr", "Frau"; 
        /// AT: "Herr", "Frau"; 
        /// CH: de-CH: "Herr", "Frau"; it-CH: "Sig.", "Sig.ra"; fr-CH: "M", "Mme"; BE: "Dhr.", "Mevr."; 
        /// NL: "Dhr.", "Mevr."
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }
    }
}
