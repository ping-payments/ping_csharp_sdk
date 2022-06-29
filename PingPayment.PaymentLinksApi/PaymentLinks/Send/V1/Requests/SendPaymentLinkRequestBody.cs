using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests
{
    public record SendPaymentLinkRequestBody
    {
        public SendPaymentLinkRequestBody
            (
            string? email, 
            string? phone, 
            IEnumerable<DistributeMethodEnum> method
            ) 
        {
            Email = email;
            Phone = phone;
            Methods = method;
        }
        /// <summary>
        /// The email of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("customer_email")]
        public string? Email { get; set; }

        /// <summary>
        /// The first name of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("customer_phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// The last name of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("methods")]
        public IEnumerable<DistributeMethodEnum> Methods { get; set; }


    }
}