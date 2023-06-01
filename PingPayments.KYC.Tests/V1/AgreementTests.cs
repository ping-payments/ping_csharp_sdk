using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.Tests;

namespace PingPayments.KYC.Tests.V1
{
    public class AgreementTests : KYCApiTestClient
    {
        [Fact]
        public async Task Get_templates_returns_200()
        {
            var request = new GetKycRequest
            {
                MerchantId = TestData.MerchantId
            };
            var response = await _api.Agreement.V1.GetAgreementTemplates();
            AssertHttpOK(response);
            Assert.True(response.Body.SuccessfulResponseBody.Any());
        }
    }
}
