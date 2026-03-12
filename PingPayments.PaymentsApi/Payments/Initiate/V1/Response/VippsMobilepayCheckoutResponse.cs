using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Response
{
    public record QuickPayVippsResponse
    {
        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
