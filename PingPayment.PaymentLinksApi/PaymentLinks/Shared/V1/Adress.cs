using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Adress
    {
        public Adress(string city, string streetAdress, string zip)
        {
            City = city;
            StreetAdress = streetAdress;
            Zip = zip;

        }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("street_addres")]
        public string StreetAdress { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

    }
}