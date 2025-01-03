using PingPayments.KYC.Agreement.V1.Shared;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create
{
    public class CreateRequestBody
    {
        /// <summary>
        /// Id of agreement template to be used
        /// </summary>
        [JsonPropertyName("agreement_template_id")]
        public Guid? TemplateId { get; set; }

        /// <summary>
        /// The url that agreement events will be sent to,
        /// only use this if you are interested in every change that happens to the agreement.
        /// How the callback looks will be dependent on the provider
        /// </summary>
        [JsonPropertyName("event_callback_url")]
        public Uri? EventCallbackUrl { get; set; }

        /// <summary>
        /// The merchant for which the agreement is created for
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public Guid? MerchantId { get; set; }

        /// <summary>
        /// The name of the agreement
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The agreement provider
        /// </summary>
        [JsonPropertyName("provider")]
        public AgreementTypeEnum Provider { get; set; }

        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [property: JsonIgnore]
        public CreateAgreementProviderParameters ProviderParameters { get; set; }

        /// <summary>
        /// Gets or Sets ProviderParameters
        /// </summary>
        [JsonPropertyName("provider_parameters")]
        public object provider_parameters => ProviderParameters;

        /// <summary>
        ///  URL that will be called when the provider state is updated
        /// </summary>
        [JsonPropertyName("provider_state_callback_url")]
        public Uri? ProviderStateCallbackUrl { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateAgreementRequestBody {\n");
            sb.Append("  AgreementTemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  EventCallbackUrl: ").Append(EventCallbackUrl).Append("\n");
            sb.Append("  MerchantId: ").Append(MerchantId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  ProviderParameters: ").Append(ProviderParameters).Append("\n");
            sb.Append("  ProviderStateCallbackUrl: ").Append(ProviderStateCallbackUrl).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
