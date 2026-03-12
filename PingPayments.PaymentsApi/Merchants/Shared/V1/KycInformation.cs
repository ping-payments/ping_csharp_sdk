using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPayments.PaymentsApi.Merchants.Shared.V1
{
    public class KycInformation
    {
        /// <summary>
        /// Indicates whether the KYC renewal process is ongoing.
        /// </summary>
        [JsonPropertyName("kyc_renewal_ongoing")]
        public bool KycRenewalOngoing { get; set; }


        /// <summary>
        /// When the latest KYC was done for this organization
        /// </summary> 
        [JsonPropertyName("latest_kyc_gathered_at")]
        public DateTimeOffset? LatestKycGatheredAt { get; set; } = default;

    }
}
