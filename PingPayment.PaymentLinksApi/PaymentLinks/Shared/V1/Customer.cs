using System;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1
{
    public record Customer
    {
        public Customer(string email, string firstName, string lastName, string phone, string refrence)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Refrence = refrence;

        }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("reference")]
        public string Refrence { get; set; }

        df


        /// <summary>
        /// Simplifies creation of customer array
        /// </summary>
        public static implicit operator Customer[](Customer customer) => new[] {customer}; 
    }
}