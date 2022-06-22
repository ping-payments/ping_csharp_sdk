using System;
using System.Net.Http;

namespace PingPayments.PaymentLinksApi
{
    public static class HttpClientExtensions
    {
        internal static string EnsureCorrectUrl(string url) =>
            url.EndsWith("/") ? 
                url : 
                $"{url}/";
        public static HttpClient ConfigurePingPaymentsClient(this HttpClient httpClient, Uri uri, Guid tenantId, string xApiSecret = null)
        {
            var headers = httpClient.DefaultRequestHeaders;
            headers.Add("tenant_id", tenantId.ToString());
            if(!string.IsNullOrWhiteSpace(xApiSecret))
            {
                headers.Add("x-api-secret", xApiSecret);
            }
            httpClient.BaseAddress = uri;
            return httpClient;
        }

        public static HttpClient ConfigurePingPaymentsClient(this HttpClient httpClient, string uri, Guid tenantId) =>
            ConfigurePingPaymentsClient(httpClient, new Uri(EnsureCorrectUrl(uri)), tenantId);
    }
}
