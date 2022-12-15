using PingPayments.KYC.Merchant.V1.Shared;
using PingPayments.KYC.Shared;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Verification
{
    public record KycVerificationRequest : KycBody
    {
        public KycVerificationRequest
        (
            BankAccount bankAccount,
            string country,
            string email,
            Guid merchantId,
            string name,
            string phone,
            LegalEntityTypeEnum type,
            Files files = null,
            PersonData? personData = null,
            OrganizationData? organizationData = null,
            Address[]? adresses = null,
            IDictionary<string, dynamic>? metadata = null,
            IDictionary<string, string>? questions = null
        )
        {
            Addresses = adresses;
            BankAccount = bankAccount;
            Country = country;
            Email = email;
            Files = files;
            MerchantId = merchantId;
            Name = name;
            Phone = phone;
            Type = type;
            PersonData = personData;
            OrganizationData = organizationData;
            Metadata = metadata;
            Questions = questions ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid MerchantId { get; set; }

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
        /// Key value pair question and answers
        /// </summary>
        [JsonPropertyName("questions")]
        public IDictionary<string, string> Questions { get; set; }

        /// <summary>
        /// Files
        /// </summary>
        [JsonPropertyName("files")]
        public Files? Files { get; set; }
    }
}

