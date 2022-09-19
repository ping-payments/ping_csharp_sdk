using PingPayments.PaymentsApi.Merchants.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Create.V1
{
    public record CreateMerchantRequest
    {
        /// <summary>
        /// Tenants name of the merchant
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The merchants underlying organization
        /// </summary>
        [JsonPropertyName("organization")]
        public Organization? Organization { get; set; }

        /// <summary>
        /// Swedish personal identity number. 
        /// The personal identity number is composed of your date of birth followed by a 4-digit number with the following pattern: ^\d{12}$
        /// </summary>
        [JsonPropertyName("person")]
        public Person? Person { get; set; }
    }
}