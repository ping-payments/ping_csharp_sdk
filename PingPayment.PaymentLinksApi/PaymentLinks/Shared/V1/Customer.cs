using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Customer
    {
        public Customer(string firstName, string lastName, string? email = null, string? phone = null, string? refrence = null)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Refrence = refrence;

        }

        /// <summary>
        /// The email of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// The first name of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number of the Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// A reference Customer intended to pay the PaymentLink
        /// </summary>
        [JsonPropertyName("reference")]
        public string? Refrence { get; set; }

    }
}