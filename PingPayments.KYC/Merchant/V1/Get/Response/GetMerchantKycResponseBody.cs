using PingPayments.KYC.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.Get.Response
{
    public record GetMerchantKycResponseBody
    {
        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("addresses")]
        public Address[] Addresses { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("bank_account")]
        public BankAccount BankaAccount { get; set; }


        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Metadata object
        /// </summary>
        [JsonPropertyName("metadata")]
        public IDictionary<string, dynamic> Metadata { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }


        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }


        /// <summary>
        /// TODO
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
