using PingPayments.PaymentsApi;
using PingPayments.Shared;
using PingPayments.Tests;

namespace PingPayments.PaymentLinksApi.Tests
{
    public class PaymentLinksApiTestClient : PaymentLinksBaseResourceTests
    {
        protected readonly IPingPaymentLinksApiClient _api;
        private readonly HttpClient _httpClient;
        protected readonly IPingPaymentsApiClient _paymentsApi;
        private readonly HttpClient _paymentsHttpClient;

        public PaymentLinksApiTestClient()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(Helpers.PingEnvironments.PaymentLinksApi.SandboxUri, TestData.TenantId);
            _api = new PingPaymentLinksApiClient(_httpClient);
            _paymentsHttpClient = new HttpClient().ConfigurePingPaymentsClient(PaymentsApi.Helpers.PingEnvironments.PaymentsApi.SandboxUri, TestData.TenantId);
            _paymentsApi = new PingPaymentsApiClient(_paymentsHttpClient);
        }
    }
}
