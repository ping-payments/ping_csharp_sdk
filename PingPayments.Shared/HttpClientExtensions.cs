using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PingPayments.PaymentsApi")]
[assembly: InternalsVisibleTo("PingPayments.PaymentLinksApi")]
[assembly: InternalsVisibleTo("PingPayments.PaymentsApi.Tests")]

namespace PingPayments.Shared
{
    public static class HttpClientExtensions
    {
        internal static string EnsureCorrectUrl(string url) =>
            url.EndsWith("/") ?
                url :
                $"{url}/";
        public static HttpClient ConfigurePingPaymentsClient(this HttpClient httpClient, Uri uri, Guid? tenantId = null, string xApiSecret = null)
        {
            var headers = httpClient.DefaultRequestHeaders;
            if (tenantId != null)
            {
                headers.Add("tenant_id", tenantId.ToString());
            }
            if (!string.IsNullOrWhiteSpace(xApiSecret))
            {
                headers.Add("x-api-secret", xApiSecret);
            }
            httpClient.BaseAddress = uri;
            return httpClient;
        }

        public static HttpClient ConfigurePingPaymentsClient(this HttpClient httpClient, string uri, Guid? tenantId = null) =>
            ConfigurePingPaymentsClient(httpClient, new Uri(EnsureCorrectUrl(uri)), tenantId);

        public static async Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string requestUri, HttpContent? content = null)
        {
            if (content == null)
                return await httpClient.DeleteAsync(requestUri);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(httpClient.BaseAddress, requestUri),
                Content = content
            };
            return await httpClient.SendAsync(request);
        }
    }
}
