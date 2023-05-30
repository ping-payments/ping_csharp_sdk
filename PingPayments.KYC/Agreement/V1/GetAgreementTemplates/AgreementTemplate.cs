using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text;

namespace PingPayments.KYC.Agreement.V1.GetAgreementTemplates
{
    public class AgreementTemplate
    {
        /// <summary>
        /// Id of the template
        /// </summary>
        /// <value>Id of the template</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Template name
        /// </summary>
        /// <value>Template name</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Provider of the agreement service
        /// </summary>
        /// <value>Provider of the agreement service</value>
        [DataMember(Name = "provider", EmitDefaultValue = false)]
        [JsonPropertyName("provider")]
        public string Provider { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AgreementTemplate {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
