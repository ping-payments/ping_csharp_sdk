using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get
{

    public class AgreementResponseBody
    {
        /// <summary>
        /// The agreement template used to create this agreement
        /// </summary>
        /// <value>The agreement template used to create this agreement</value>
        [JsonPropertyName("agreement_template_id")]
        public Guid? AgreementTemplateId { get; set; }

        /// <summary>
        /// The merchant for which the agreement was created for
        /// </summary>
        /// <value>The merchant for which the agreement was created for</value>
        [JsonPropertyName("merchant_id")]
        public Guid? MerchantId { get; set; }

        /// <summary>
        /// The name of the agreement
        /// </summary>
        /// <value>The name of the agreement</value>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The agreement provider
        /// </summary>
        /// <value>The agreement provider</value>
        [JsonPropertyName("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Agreement specific data from provider
        /// </summary>
        /// <value>Agreement specific data from provider</value>
        [JsonPropertyName("provider_data")]
        public Dictionary<string, object> ProviderData { get; set; }

        /// <summary>
        /// When the agreement was published
        /// </summary>
        /// <value>When the agreement was published</value>
        [JsonPropertyName("published_at")]
        public string PublishedAt { get; set; }

        /// <summary>
        /// If the agreement has been fully signed
        /// </summary>
        /// <value>If the agreement has been fully signed</value>
        [JsonPropertyName("signed")]
        public bool? Signed { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Agreement {\n");
            sb.Append("  AgreementTemplateId: ").Append(AgreementTemplateId).Append("\n");
            sb.Append("  MerchantId: ").Append(MerchantId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  ProviderData: ").Append(ProviderData).Append("\n");
            sb.Append("  PublishedAt: ").Append(PublishedAt).Append("\n");
            sb.Append("  Signed: ").Append(Signed).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
