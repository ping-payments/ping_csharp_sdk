using System.Collections.Concurrent;

namespace PingPayments.Shared.Helpers
{
    internal static class GenericHelpers
    {
        internal static Func<T, TResult> LazyMemoize<T, TResult>(this Func<T, TResult> f)
        {
            var cache = new ConcurrentDictionary<T, Lazy<TResult>>();
            return a => cache.GetOrAdd(a, new Lazy<TResult>(() => f(a))).Value;
        }
    }
}
