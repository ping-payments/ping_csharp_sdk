﻿using PingPayments.KYC.Shared;
using PingPayments.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Shared
{
    public record KycBody : GuidResponseBody
    {
        /// <summary>
        /// Array of Addresses
        /// </summary>
        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }

        /// <summary>
        /// Payout accounts for the Merchant. Not needed if "BankAccounts" is used.
        /// </summary>
        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// The list of payout accounts for the Merchants
        /// </summary>
        [JsonPropertyName("bank_accounts")]
        public BankAccount[] BankAccounts { get; set; }

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
        public OrganizationData OrganizationData { get; set; }

        /// <summary>
        /// Data for person
        /// </summary>
        [JsonPropertyName("person_data")]
        public PersonData PersonData { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Merchant status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Type of legal entity
        /// </summary>
        [JsonPropertyName("type")]
        public LegalEntityTypeEnum? Type { get; set; }
    }
}
