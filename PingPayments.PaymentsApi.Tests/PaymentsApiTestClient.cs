using PingPayments.Mimic;
using PingPayments.PaymentsApi.Helpers;
using PingPayments.Shared;
using PingPayments.Tests;
using System.Net.Http;

namespace PingPayments.PaymentsApi.Tests
{
    public class PaymentsApiTestClient : BaseResourceTests
    {
        protected readonly IPingPaymentsApiClient _api;
        protected readonly IPingMimicApiClient _mimicApi;
        private readonly HttpClient _httpClient;
        private readonly HttpClient _mimicHttpClient;

        public PaymentsApiTestClient()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(PingEnvironments.PaymentsApi.SandboxUri, TestData.TenantId);
            _mimicHttpClient = new HttpClient().ConfigurePingPaymentsClient(Mimic.Helpers.PingEnvironments.MimicApi.SandboxUri, TestData.TenantId);
            _api = new PingPaymentsApiClient(_httpClient);
            _mimicApi = new PingMimicApiClient(_mimicHttpClient);
        }
    }
}
