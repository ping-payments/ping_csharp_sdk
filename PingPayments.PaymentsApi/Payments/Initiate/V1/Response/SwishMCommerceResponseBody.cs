using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record SwishMCommerceResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public SwishMCommerceResponse ProviderMethodResponse { get; set; }
    }
}
