using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Merchant.V1.Get;
using PingPayments.Tests;

namespace PingPayments.KYC.Tests.V1
{
    public class AgreementTests : KYCApiTestClient
    {
        [Fact]
        public async Task Verify_a_full_agreement_flow()
        {
            var agreementResponse = await _api.Agreement.V1.GetAgreementTemplates();
            AssertHttpOK(agreementResponse);

            var templateId = agreementResponse.Body.SuccessfulResponseBody.First().Id;

            var createAgreementRequest = new CreateAgreementRequestBody
            {
                AgreementTemplateId = templateId,
                MerchantId = TestData.MerchantId,
                Name = "Test",
                Provider = TypeOfAgreementToCreate.oneflow,
                ProviderParameters = null
            };
            var createAgreementResponse = await _api.Agreement.V1.Create(createAgreementRequest);
            AssertHttpOK(createAgreementResponse);

            var getAgreementResponse = await _api.Agreement.V1.Get(createAgreementResponse.Body.SuccessfulResponseBody.Id);
            AssertHttpOK(getAgreementResponse);

        }

    }
}
