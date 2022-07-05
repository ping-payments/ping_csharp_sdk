using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Supplier
    {
        public Supplier
            (
                string name, 
                string? city = null, 
                string? organizationNumber = null, 
                string? website = null, 
                string? zip = null
            )
        {
            Name = name;
            City = city;
            OrganizationNumber = organizationNumber;
            Website = website;
            Zip = zip;
        }

        /// <summary>
        /// The name of the Supplier 
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///  The city where the Supplier is located
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// The organizationNumber of the supplier 
        /// </summary>
        [JsonPropertyName("organization_number")]
        public string? OrganizationNumber { get; set; }

        /// <summary>
        /// A webbsite associated with the supplier
        /// </summary>
        [JsonPropertyName("website")]
        public string? Website { get; set; }

        /// <summary>
        /// The zip code for the supplier
        /// </summary>
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }
    }
}