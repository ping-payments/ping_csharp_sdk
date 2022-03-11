using Ping.Checkout.Web.Enums.Domain;

namespace PaymentsApiSDK.Interfaces
{
    public interface IPaymentItem
    {
        decimal Amount { get; set; }
        string Name { get; set; }
        decimal Vat { get; set;}
    }
}
