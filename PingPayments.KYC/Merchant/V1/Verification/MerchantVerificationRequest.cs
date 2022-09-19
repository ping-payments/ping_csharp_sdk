using PingPayments.KYC.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Verification
{
    public record MerchantVerificationRequest
    {

        /// <summary>
        /// Array of Addresses
        /// </summary>
        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }

        /// <summary>
        /// The payout account of the Merchant
        /// </summary>
        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; }

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
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; }

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
        /// Data for an organization
        /// </summary>
        [JsonPropertyName("organization_data")]
        public OrganizationData? OrganizationData { get; set; }


        /// <summary>
        /// Data for person
        /// </summary>
        [JsonPropertyName("person_data")]
        public PersonData? PersonData { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string phone { get; set; }

        /// <summary>
        /// Key value pair question and answers
        /// </summary>
        [JsonPropertyName("questions")]
        public IDictionary<string, string> Questions { get; set; }

        /// <summary>
        /// Tenant ID
        /// </summary>
        [JsonPropertyName("tenant_id")]
        public string TenantId { get; set; }

        /// <summary>
        /// Type of legal entity
        /// </summary>
        [JsonPropertyName("type")]
        public LegalEntityTypeEnum Type { get; set; }

    }
}
