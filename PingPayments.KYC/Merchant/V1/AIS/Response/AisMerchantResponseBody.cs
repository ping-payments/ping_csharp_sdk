using PingPayments.Shared;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Merchant.V1.AIS.Response
{
    public record AisMerchantResponseBody : EmptySuccessfulResponseBody
    {
        [JsonPropertyName("ais_url")]
        public Uri Url { get; set; }

        [JsonPropertyName("verification_id")]
        public string VerificationId { get; set; }
    }
}
