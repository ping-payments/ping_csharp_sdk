using PaymentsApiSdk.Shared;
using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.Initiate.Response
{
    public record InitiatePaymentResponseBody : GuidResponseBody
    {

        [JsonPropertyName("swish")]
        public Swish? Swish { get; set; }

        [JsonPropertyName("verifone")]
        public Verifone? Verifone { get; set; }

        [JsonPropertyName("billmate")]
        public Billmate? Billmate { get; set; }
    }
}
