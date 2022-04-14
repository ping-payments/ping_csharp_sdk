using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> InList<T>(this T item) => new[] { item };
    }
}
