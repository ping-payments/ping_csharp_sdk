using System;
using System.Net.Http;

namespace PingPayments.PaymentsApi
{
    public static class HttpClientExtensions
    {
        public static HttpClient ConfigurePingPaymentsClient(this HttpClient httpClient, Uri uri, Guid tenantId)
        {
            var headers = httpClient.DefaultRequestHeaders;
            headers.Add("tenant_id", tenantId.ToString());
            httpClient.BaseAddress = uri;
            return httpClient;
        }

        public static HttpClient ConfigurePingPaymentsClient(this HttpClient httpClient, string uri, Guid tenantId) =>
            ConfigurePingPaymentsClient(httpClient, new Uri(uri), tenantId);
    }
}
