using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{

    public record VippsMobilepayCheckoutResponse
    {
        /// <summary>
        /// Used for opening Vipps url by redirect.
        /// </summary>
        [JsonPropertyName("checkout_url")]
        public string CheckoutUrl { get; set; }
    }
}
