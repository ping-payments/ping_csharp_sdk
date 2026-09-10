using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response
{
    public record SwishRecurringConsentResponseBody : ProviderMethodResponseBody
    {
        [JsonPropertyName("provider_method_response")]
        public SwishRecurringConsentResponse? ProviderMethodResponse { get; set; }
    }
}
