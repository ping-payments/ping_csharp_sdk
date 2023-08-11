using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Publish.Oneflow
{
    public class PublishAgreementParameters : PublishProviderParameters
    {
        /// <summary>
        /// Message to be sent along with the invitation
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Subject of the message
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PublishOneflowAgreementParameters {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
