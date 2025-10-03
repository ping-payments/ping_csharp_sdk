using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record VippsMobilePayResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public VippsMobilePayResponse ProviderMethodResponse { get; set; }
    }
}
