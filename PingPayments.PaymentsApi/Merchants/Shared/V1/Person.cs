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
        /// Name of the person
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; } = null;

        /// <summary>
        /// Swedish personal identity number. 
        /// The personal identity number is composed of your date of birth followed by a 4-digit number with the following pattern: ^\d{12}$
        /// </summary>
        [JsonPropertyName("se_personal_identity_number")]
        public string? SePersonalIdentityNumber { get; set; } = null;

        /// <summary>
        /// Danish Civil Registration Number (CPR) associated with the entity.
        /// </summary>
        [JsonPropertyName("dk_civil_registration_number")]
        public string? DkCivilRegistrationNumber { get; set; } = null;

        /// <summary>
        /// Norwegian national identity number.
        /// </summary>
        [JsonPropertyName("no_identity_number")]
        public string? NoIdentityNumber { get; set; } = null;
    }
}
