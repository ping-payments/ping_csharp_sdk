using PingPayments.KYC.Agreement.V1.Get.Oneflow;
using PingPayments.KYC.Agreement.V1.Shared;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get
{
    public class AgreementResponseBody
    {
        /// <summary>
        /// The agreement template used to create this agreement
        /// </summary>
        [JsonPropertyName("agreement_template_id")]
        public Guid? AgreementTemplateId { get; set; }

        /// <summary>
        /// The merchant for which the agreement was created for
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
        /// Agreement specific data from provider
        /// </summary>
        //[JsonIgnore()]
        public AgreementProviderData ProviderData => Provider switch
        {
            AgreementTypeEnum.oneflow => JsonSerializer.Deserialize<Contract>(
                provider_data.GetRawText(),
                new JsonSerializerOptions() { Converters = { new JsonStringEnumConverter() } }
            ),
            _ => null
        };

        [JsonPropertyName("provider_data")]
        public JsonElement provider_data { get; set; }

        /// <summary>
        /// When the agreement was published
        /// </summary>
        [JsonPropertyName("published_at")]
        public string PublishedAt { get; set; }

        /// <summary>
        /// If the agreement has been fully signed
        /// </summary>
        [JsonPropertyName("signed")]
        public bool? Signed { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Agreement {\n");
            sb.Append("  AgreementTemplateId: ").Append(AgreementTemplateId).Append("\n");
            sb.Append("  MerchantId: ").Append(MerchantId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Provider: ").Append(Provider).Append("\n");
            sb.Append("  PublishedAt: ").Append(PublishedAt).Append("\n");
            sb.Append("  Signed: ").Append(Signed).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
