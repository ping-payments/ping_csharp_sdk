using System;

namespace PingPayments.PaymentsApi.Helpers
{
    public static class AmountHelpers
    {
        public static int ToMinorCurrency(this int amount) => Convert.ToInt32(amount * 100);
        public static int ToMinorCurrency(this double amount) => Convert.ToInt32(amount * 100);
        public static int ToMinorCurrency(this decimal amount) => Convert.ToInt32(amount * 100);
        public static decimal FromMinorCurrency(this int amount) => amount / 100m;
    }
}
