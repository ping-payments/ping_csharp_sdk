using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record ManualCorrections
    {
        /// <summary>
        /// The corrected amount in minor currency.
        /// If the amount is negative it means that the the correction was from the organization to someone else.
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }


        /// <summary>
        /// Name of the person who performed the manuel correction
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }


        /// <summary>
        /// Norwegian organization number
        /// </summary>
        [JsonPropertyName("no_organization_number")]
        public string? NoOrganizationNumber { get; set; }


        /// <summary>
        /// Danish organization number
        /// </summary>
        [JsonPropertyName("dk_organization_number")]
        public string? DkOrganizationNumber { get; set; }


        /// <summary>
        /// Swedish organization number
        /// </summary>
        [JsonPropertyName("se_organization_number")]
        public string? SeOrganizationNumber { get; set; }
    }
}
