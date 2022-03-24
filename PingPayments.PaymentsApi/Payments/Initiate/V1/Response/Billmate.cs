using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record Billmate
    {
        public Billmate(string invoiceUrl) => InvoiceUrl = invoiceUrl;
        
        [JsonPropertyName("invoice_url")]
        public string InvoiceUrl { get; set; }        
    }
}
