using PingPayments.PaymentsApi.Helpers;


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
