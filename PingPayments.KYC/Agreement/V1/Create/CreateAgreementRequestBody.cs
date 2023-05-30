using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create
{
    public class CreateAgreementRequestBody
    {
        /// <summary>
        /// The agreement template to be used
        /// </summary>
        /// <value>The agreement template to be used</value>
        [JsonPropertyName("agreement_template_id")]
        public Guid? AgreementTemplateId { get; set; }

        /// <summary>
        /// The merchant for which the agreement is created for
        /// </summary>
        /// <value>The merchant for which the agreement is created for</value>
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
        /// Gets or Sets ProviderParameters
        /// </summary>
        [JsonPropertyName("provider_parameters")]
        public Dictionary<string, object> ProviderParameters { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateAgreementRequestBody {\n");
            sb.Append("  AgreementTemplateId: ").Append(AgreementTemplateId).Append("\n");
            sb.Append("  MerchantId: ").Append(MerchantId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  ProviderParameters: ").Append(ProviderParameters).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
