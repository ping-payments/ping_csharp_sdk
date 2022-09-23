using PingPayments.KYC.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Get.Response
{
    public record KycResponseBody
    {
        /// <summary>
        /// Addresses
        /// </summary>
        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }

        /// <summary>
        /// The payout account of the Merchant
        /// </summary>
        [JsonPropertyName("bank_account")]
        public BankAccount BankaAccount { get; set; }

        /// <summary>
        /// Country in ISO-3166
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Metadata object
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }


        /// <summary>
        /// Phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }


        /// <summary>
        /// Type of legal entity
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
