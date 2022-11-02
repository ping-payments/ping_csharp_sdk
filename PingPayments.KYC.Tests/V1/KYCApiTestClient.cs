using PingPayments.KYC.Helpers;
using PingPayments.Shared;
using PingPayments.Tests;

namespace PingPayments.KYC.Tests.V1
{
    public class KYCApiTestClient : BaseResourceTests
    {
        protected readonly IPingKycApiClient _api;
        protected readonly HttpClient _httpClient;

        public KYCApiTestClient()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(PingEnvironments.KYC.SandboxUri);
            _api = new PingKycApiClient(_httpClient);
        }

    }
}
