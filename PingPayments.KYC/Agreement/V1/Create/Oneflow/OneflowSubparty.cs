using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class Subparty : Person
    {
        /// <summary>
        /// Oneflow sub party title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
