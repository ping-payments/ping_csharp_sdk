using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response
{
    public record BankgirotAutogiroConsentResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public BankgirotAutogiroConsentResponse? ProviderMethodResponse { get; set; }
    }
}
