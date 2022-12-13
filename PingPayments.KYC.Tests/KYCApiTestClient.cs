using PingPayments.KYC.Helpers;
using PingPayments.Shared;
using PingPayments.Tests;

namespace PingPayments.KYC.Tests
{
    public class KYCApiTestClient : BaseResourceTests
    {
        protected readonly IPingKycApiClient _api;
        protected readonly HttpClient _httpClient;

        public KYCApiTestClient()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(PingEnvironments.KYC.SandboxUri, TestData.TenantId);
            _api = new PingKycApiClient(_httpClient);
        }

    }
}
