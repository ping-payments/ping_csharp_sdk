using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Helpers
{
    internal static class HttpClientHelpers
    {
        internal static async Task<string> ReadAsStringAsyncMemoized(this HttpContent content) => 
            await (ReadAsStringAsync.LazyMemoize())(content);

        internal static Func<HttpContent, Task<string>> ReadAsStringAsync = (content) => content.ReadAsStringAsync();
    }
}
