using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.Create.Oneflow;
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
                ProviderParameters = new OneflowProviderParameters
                {
                    Party = new OneflowOrganization
                    {
                        Country = OneflowCountryCode.SE,
                        Identity = "559171-1873",
                        Name = "RaJo Software AB",
                        SubParties = new List<OneflowSubparty>
                        {
                            new OneflowSubparty
                            {
                                Identity = "199201154953",
                                Name = "Johannes Norrbacka",
                                Email = "johannes@monetax.se",
                                Country = OneflowCountryCode.SE,
                                Editor = true,
                                PhoneNumber = "4673879474",
                                Signatory = true,
                                SignMethod = OneflowSignMethod.swedish_bankid,
                                Title = "Master of coin"
                            }
                        }

                    }
                }
            };
            var createAgreementResponse = await _api.Agreement.V1.Create(createAgreementRequest);
            AssertHttpOK(createAgreementResponse);

            var getAgreementResponse = await _api.Agreement.V1.Get(createAgreementResponse.Body.SuccessfulResponseBody.Id);
            AssertHttpOK(getAgreementResponse);

        }

    }
}
