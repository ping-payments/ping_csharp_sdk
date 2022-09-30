using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public record Merchant : GuidResponseBody
    {
        /// <summary>
        /// Tenants name of the merchant
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email to the merchant
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number to the merchant
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Status of the merchant
        /// </summary>
        [JsonPropertyName("status")]
        public MerchantStatus Status { get; set; }

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
