using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Supplier
    {
        public Supplier(string city, string name, string organizationNumber, string website, string zip)
        {
            City = city;
            Name = name;
            OrganizationNumber = organizationNumber;
            Website = website;
            Zip = zip;

        }
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("organization_number")]
        public string OrganizationNumber { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

    }
}