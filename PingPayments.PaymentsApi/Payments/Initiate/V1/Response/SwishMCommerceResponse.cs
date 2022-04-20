using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{

    public record SwishMCommerceResponse
    {
        /// <summary>
        /// Used for opening Swish in Mobile Phone by redirect. Does not contain callbackUrl.
        /// </summary>
        [JsonPropertyName("url")]
        public string SwishUrl { get; set; }

        /// <summary>
        /// Used for displaying Qr Code for scanning of swish payment
        /// </summary>
        [JsonPropertyName("qr_code")]
        public string? QrCode { get; set; }
    }    
}
