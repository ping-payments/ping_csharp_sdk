using PingPayments.PaymentsApi.Helpers;
using PingPayments.Shared;
using PingPayments.Tests;
using System.Net.Http;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentsApiTestClient : BaseResourceTests
    {
        protected readonly IPingPaymentsApiClient _api;
        private readonly HttpClient _httpClient;

        public PaymentsApiTestClient()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(PingEnvironments.PaymentsApi.SandboxUri, TestData.TenantId);
            _api = new PingPaymentsApiClient(_httpClient);
        }
    }
}
