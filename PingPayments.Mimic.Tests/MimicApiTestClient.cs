using PingPayments.Mimic.Helpers;
using PingPayments.Shared;
using PingPayments.Tests;

namespace PingPayments.Mimic.Tests
{
    public class MimicApiTestClient : BaseResourceTests
    {
        protected readonly IPingMimicApiClient _api;
        protected readonly HttpClient _httpClient;

        public MimicApiTestClient()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(PingEnvironments.MimicApi.SandboxUri, TestData.TenantId);
            _api = new PingMimicApiClient(_httpClient);
        }
    }
}
