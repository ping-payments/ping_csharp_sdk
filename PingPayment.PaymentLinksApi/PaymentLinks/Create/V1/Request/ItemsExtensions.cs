using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static class ItemsExtensions
    {
        public static int TotalAmountMinorCurrencyUnit(this IEnumerable<Item> items) => items.Sum(o => o.Price * o.Quantity);

        public static decimal TotalAmountInCurrencyUnit(this IEnumerable<Item> items) => items.Sum(o => o.Price * o.Quantity).FromMinorCurrencyUnit();
    }
}
