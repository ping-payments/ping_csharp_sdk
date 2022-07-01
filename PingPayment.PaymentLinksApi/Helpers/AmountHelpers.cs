using System;

namespace PingPayments.PaymentLinksApi.Helpers
{
    public static class AmountHelpers
    {
        public static int ToMinorCurrencyUnit(this int amount) => Convert.ToInt32(amount * 100);
        public static int ToMinorCurrencyUnit(this double amount) => Convert.ToInt32(amount * 100);
        public static int ToMinorCurrencyUnit(this decimal amount) => Convert.ToInt32(amount * 100);
        public static decimal FromMinorCurrencyUnit(this int amount) => amount / 100m;
    }
}
