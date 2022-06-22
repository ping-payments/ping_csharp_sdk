using PingPayments.PaymentsApi.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.Helpers
{
    internal static class HttpClientHelpers
    {
        internal static async Task<string> ReadAsStringAsyncMemoized(this HttpContent content)
        {
            return await ReadAsStringAsync.LazyMemoize()(content);
        }

        internal static Func<HttpContent, Task<string>> ReadAsStringAsync = (content) => content.ReadAsStringAsync();
    }
}
