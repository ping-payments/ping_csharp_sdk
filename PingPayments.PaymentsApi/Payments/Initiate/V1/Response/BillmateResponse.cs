using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record BillmateResponse : ProviderMethodResponseBody
    {
        [JsonPropertyName("invoice_url")]
        public string InvoiceUrl { get; set; }        
    }
}
