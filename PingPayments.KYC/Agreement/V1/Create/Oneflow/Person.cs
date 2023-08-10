using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class Person : Party
    {
        /// <summary>
        /// Person who can edit agreement information
        /// </summary>
        [JsonPropertyName("editor")]
        public bool? Editor { get; set; }

        /// <summary>
        /// Email used to deliver the agreement
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Phone number used to deliver the agreement
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Sign method
        /// </summary>
        [JsonPropertyName("sign_method")]
        public SignMethodEnum SignMethod { get; set; }

        /// <summary>
        /// Person who can sign agreement
        /// </summary>
        /// <value>If the person can sign the agreement</value
        [JsonPropertyName("signatory")]
        public bool? Signatory { get; set; }

        /// <summary>
        /// Type can only be person
        /// </summary>
        /// <value>The type can only be person</value>
        [JsonPropertyName("type")]
        public PartyTypeEnum Type => PartyTypeEnum.person;
    }
}
