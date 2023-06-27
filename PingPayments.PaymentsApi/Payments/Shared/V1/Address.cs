using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Address
    {
        /// <summary>
        /// First name of payer
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of payer 
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Address os residence
        /// </summary>
        [JsonPropertyName("address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Zip code of residence
        /// </summary>
        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// City of residence
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

    }
}
