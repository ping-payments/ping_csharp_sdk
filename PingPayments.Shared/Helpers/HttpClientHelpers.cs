using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PingPayments.PaymentsApi")]
[assembly: InternalsVisibleTo("PingPayments.PaymentLinksApi")]

namespace PingPayments.Shared.Helpers
{
    internal static class HttpClientHelpers
    {
        internal static async Task<string> ReadAsStringAsyncMemoized(this HttpContent content) =>
            await (ReadAsStringAsync.LazyMemoize())(content);

        internal static Func<HttpContent, Task<string>> ReadAsStringAsync = (content) => content.ReadAsStringAsync();
    }
}
