using Ping.Checkout.Web.Enums.Domain;
using PaymentsApiSDK.Interfaces;

namespace PaymentsApiSDK.Models
{
    public record PaymentItem : IPaymentItem
    {
        public PaymentItem(decimal amount, string name, decimal vat)
        {
            Amount = amount;
            Name = name;
            Vat = vat;
        }

        public decimal Amount { get; set; }
        public string Name { get; set; }
        public decimal Vat { get; set; }
    }
}
