using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Create.V1
{

    public record CreateInvoiceRequest(string? DokumentName, ReferenceTypeEnum ReferenceType)
    {
        /// <summary>
        /// Name of the document
        /// </summary>
        [JsonPropertyName("document_name")]
        public string? DokumentName { get; set; } = DokumentName;

        /// <summary>
        /// Reference type the end user will use to pay the invoice
        /// </summary>
        [JsonPropertyName("reference_type")]
        public ReferenceTypeEnum ReferenceType { get; set; } = ReferenceType;
    }
}
