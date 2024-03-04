using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1.Deposit
{
    public record Customer
    {

        /// <summary>
        /// Name of the customer
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Street address of the customer
        /// </summary>
        [JsonPropertyName("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Postal code of the customer
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// City of the customer
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}
