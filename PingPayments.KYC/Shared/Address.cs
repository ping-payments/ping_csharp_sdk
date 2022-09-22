using System.Text.Json.Serialization;

namespace PingPayments.KYC.Shared
{
    public record Address
    {

        [JsonPropertyName("city")]
        public string City { get; set; }


        [JsonPropertyName("country")]
        public string Country { get; set; }


        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }


        [JsonPropertyName("street")]
        public string Street { get; set; }


        [JsonPropertyName("street_no")]
        public string StreetNo { get; set; }

        /// <summary>
        /// Simplifies creation of order items array
        /// </summary>
        public static implicit operator Address[](Address adress) => new[] { adress };
    }
}
