using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1
{
    public record SendPaymentLinkRequestBody
    {

        

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