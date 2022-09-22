using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record Address
    {
        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }


        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("street")]
        public string Street { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("street_no")]
        public string StreetNo { get; set; }

        /// <summary>
        /// Simplifies creation of order items array
        /// </summary>
        public static implicit operator Address[](Address adress) => new[] { adress };
    }
}
