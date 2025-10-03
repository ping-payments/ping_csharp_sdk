using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.VippsMobilepayCheckout
{
    public record PrefillCustomer
    {

        /// <summary>
        /// Name of the customer
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// Country of the customer
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Street address of the customer
        /// </summary>
        [JsonPropertyName("street_address")]
        public string? StreetAddress { get; set; }

        /// <summary>
        /// Postal code of the customer
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Email of the customer
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }


        /// <summary>
        /// FirstName of the customer
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }


        /// <summary>
        /// LastName of the customer
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// PhoneNumber of the customer
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }
    }
}
