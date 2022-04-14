using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record PingDepositResponse : ProviderMethodResponseBody
    {
        public PingDepositResponse(string reference) => Reference = reference;
        
        [JsonPropertyName("reference")]
        public string Reference { get; set; }        
    }
}
