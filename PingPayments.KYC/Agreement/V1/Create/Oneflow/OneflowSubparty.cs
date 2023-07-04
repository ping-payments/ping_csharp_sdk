using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Create.Oneflow
{
    public class OneflowSubparty : OneflowPerson
    {
        /// <summary>
        /// Sign method
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
