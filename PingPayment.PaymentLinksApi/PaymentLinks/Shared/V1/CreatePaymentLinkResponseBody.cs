using PingPayments.PaymentLinksApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record CreatePaymentLinkResponseBody : GuidResponseBody
    {
        [JsonPropertyName("checkout_url")]
        public string? CheckoutUrl { get; set; }
    }
}
