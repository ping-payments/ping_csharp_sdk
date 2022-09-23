using PingPayments.KYC.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Verification
{
    public record KycVerificationRequest
    (
        BankAccount BankAccount,
        string Country,
        string Email,
        Guid MerchantId,
        string Name,
        string Phone,
        Guid TenantId,
        string Type,
        PersonData? PersonData = null,
        OrganizationData? OrganizationData = null,
        Address[]? Adresses = null,
        IDictionary<string, dynamic>? Metadata = null,
        IDictionary<string, string>? Questions = null
    )
    {

        /// <summary>
        /// Array of Addresses
        /// </summary>
        [JsonPropertyName("addresses")]
        public Address[]? Addresses { get; set; } = Adresses;

        /// <summary>
        /// The payout account of the Merchant
        /// </summary>
        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; } = BankAccount;

        /// <summary>
        /// Country in ISO-3166
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; } = Country;

        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = Email;

        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; } = MerchantId;

        /// <summary>
        /// Metadata object
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic>? Metadata { get; set; } = Metadata;

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = Name;

        /// <summary>
        /// Data for an organization
        /// </summary>
        [JsonPropertyName("organization_data")]
        public OrganizationData? OrganizationData { get; set; } = OrganizationData;


        /// <summary>
        /// Data for person
        /// </summary>
        [JsonPropertyName("person_data")]
        public PersonData? PersonData { get; set; } = PersonData;

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = Phone;

        /// <summary>
        /// Key value pair question and answers
        /// </summary>
        [JsonPropertyName("questions")]
        public IDictionary<string, string> Questions { get; set; } = Questions ?? new Dictionary<string, string>();

        /// <summary>
        /// Tenant ID
        /// </summary>
        [JsonPropertyName("tenant_id")]
        public Guid TenantId { get; set; } = TenantId;

        /// <summary>
        /// Type of legal entity
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = Type;

    }
}

