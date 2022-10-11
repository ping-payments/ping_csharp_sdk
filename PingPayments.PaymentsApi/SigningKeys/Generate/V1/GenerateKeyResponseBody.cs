using PingPayments.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.SigningKeys.Generate.V1
{
    public record GenerateKeyResponseBody : EmptySuccessfulResponseBody
    {
        /// <summary>
        /// Base64 encoded binary key
        /// </summary>
        [JsonPropertyName("public_key")]
        public string publicKey { get; set; }
    }
}
