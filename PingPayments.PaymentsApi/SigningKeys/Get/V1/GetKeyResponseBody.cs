using PingPayments.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.SigningKeys.Get.V1
{
    public record GetKeyResponseBody : EmptySuccessfulResponseBody
    {
        /// <summary>
        /// Base64 encoded public signing key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
