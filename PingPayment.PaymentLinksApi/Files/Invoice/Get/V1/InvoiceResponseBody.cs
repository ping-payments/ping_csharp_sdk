using PingPayments.PaymentLinksApi.Shared;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.Files.Invoice.Get.V1
{
    public record InvoiceResponseBody : EmptySuccesfulResponseBody
    {

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}