using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record QuickPayVippsResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public QuickPayVippsResponse ProviderMethodResponse { get; set; }
    }
}
