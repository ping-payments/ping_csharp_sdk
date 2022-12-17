using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public record Person
    {

        /// <summary>
        /// A string that represents the two-letter ISO 3166-2 country code of which the person is a citizen of or resides in.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }


        /// <summary>
        /// Swedish personal identity number. 
        /// The personal identity number is composed of your date of birth followed by a 4-digit number with the following pattern: ^\d{12}$
        /// </summary>
        [JsonPropertyName("se_personal_identity_number")]
        public string? SePersonalIdentityNumber { get; set; }
    }
}
