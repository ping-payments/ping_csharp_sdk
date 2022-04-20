using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record BillmateResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public BillmateResponse ProviderMethodResponse { get; set; }
    }
}
