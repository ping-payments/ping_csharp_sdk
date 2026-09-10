using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PayPalPPCPPaymentResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public PayPalPPCPPaymentResponse ProviderMethodResponse { get; set; }
    }
}
