using PingPayments.Shared;
using System.Text.Json.Serialization;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record CreatePaymentLinkResponseBody : GuidResponseBody
    {
        [JsonPropertyName("checkout_url")]
        public string? CheckoutUrl { get; set; }
    }
}
