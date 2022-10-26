using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public record Funds
    {
        /// <summary>
        /// Additional funds that have been received in connection to this update. Given in minor unit of currency (eg.öre for SEK)
        /// </summary>
        [JsonPropertyName("received")]
        public int Received { get; set; }


        /// <summary>
        /// Total amount of funds received for Payment as of this update. Given in minor unit of currency (eg.öre for SEK)
        /// </summary>
        [JsonPropertyName("received_total")]
        public int ReceivedTotal { get; set; }
    }
}
