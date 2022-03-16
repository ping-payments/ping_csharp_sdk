using System.Text.Json.Serialization;

namespace PaymentsApiSdk.Payments.InitiatePayment.Response
{
    public record Billmate
    {
        public Billmate(string invoiceUrl) => InvoiceUrl = invoiceUrl;
        
        [JsonPropertyName("invoice_url")]
        public string InvoiceUrl { get; set; }        
    }
}
