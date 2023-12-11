﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Payer
    {
        public Payer(string? email = null, string? ipAddress = null, string? name = null, string? phoneNumber = null, PayerAddress? payerAddress = null, LegalEntity? identity = null)
        {
            Email = email;
            IpAddress = ipAddress;
            Name = name;
            PhoneNumber = phoneNumber;
            Identity = identity;
            Address = payerAddress ?? new PayerAddress();
        }
        /// <summary>
        /// Address of payer
        /// </summary>
        [JsonPropertyName("address")]
        public PayerAddress? Address { get; set; }

        /// <summary>
        /// Email of payer
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Legal entity information
        /// </summary>
        [JsonPropertyName("identity")]
        public LegalEntity? Identity { get; set; }

        /// <summary>
        /// IP-address of payer
        /// </summary>
        [JsonPropertyName("ip_address")]
        public string? IpAddress { get; set; }

        /// <summary>
        /// Name of payer
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Phone number of payer
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }
    }
}
