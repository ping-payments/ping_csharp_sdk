using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.Create.Oneflow;
using PingPayments.KYC.Agreement.V1.Get;
using PingPayments.KYC.Agreement.V1.Get.Oneflow;
using PingPayments.KYC.Agreement.V1.Publish;
using PingPayments.KYC.Agreement.V1.PublishAgreement.Oneflow;
using PingPayments.KYC.Agreement.V1.Update;
using PingPayments.KYC.Agreement.V1.Update.Oneflow;
using PingPayments.Tests;

namespace PingPayments.KYC.Tests.V1
{
    public class AgreementTests : KYCApiTestClient
    {
        [Fact]
        public async Task Verify_a_full_agreement_flow_for_organization()
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
                                PhoneNumber = "46701234567",
                                Signatory = true,
                                SignMethod = OneflowSignMethod.standard_esign,
                                Title = "Master of coin"
                            }
                        }

                    }
                }
            };
            var createAgreementResponse = await _api.Agreement.V1.Create(createAgreementRequest);
            AssertHttpOK(createAgreementResponse);
            
            var agreementId = createAgreementResponse.Body.SuccessfulResponseBody.Id;
            var getAgreementResponse = await _api.Agreement.V1.Get(agreementId);
            AssertHttpOK(getAgreementResponse);

            AgreementResponseBody agreement = getAgreementResponse.Body.SuccessfulResponseBody;
            Assert.NotNull(agreement.ProviderData);

            var updatePayload = new UpdateAgreementRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new OneflowUpdateAgreementProviderParameters
                {
                    DataFields = new[] {
                      new OneflowUpdateAgreementDataField
                      {
                          Id = "first-name",
                          Value = "August"
                      }
                    }
                }
            };
            var updateAgreementResponse = await _api.Agreement.V1.UpdateAgreement(updatePayload);
            AssertHttpNoContent(updateAgreementResponse);

            var publishPayload = new PublishAgreementRequest
            {
                AgreementId= agreementId,
                ProviderParameters = new PublishOneflowAgreementParameters
                {
                    Subject = "Signa detta mannen!",
                    Message = "Inte alls en scam!"
                }
            };
            var publishAgreementResponse = await _api.Agreement.V1.PublishAgreement(publishPayload);
            AssertHttpNoContent(publishAgreementResponse);
        }


        [Fact]
        public async Task Verify_a_full_agreement_flow_for_person()
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
                    Party = new OneflowPerson
                    {
                        Identity = "199201154953",
                        Name = "Johannes Norrbacka",
                        Email = "johannes@monetax.se",
                        Country = OneflowCountryCode.SE,
                        Editor = true,
                        PhoneNumber = "46701234567",
                        Signatory = true,
                        SignMethod = OneflowSignMethod.standard_esign
                    }
                }
            };
            var createAgreementResponse = await _api.Agreement.V1.Create(createAgreementRequest);
            AssertHttpOK(createAgreementResponse);

            var agreementId = createAgreementResponse.Body.SuccessfulResponseBody.Id;
            var getAgreementResponse = await _api.Agreement.V1.Get(agreementId);
            AssertHttpOK(getAgreementResponse);

            AgreementResponseBody agreement = getAgreementResponse.Body.SuccessfulResponseBody;
            Assert.NotNull(agreement.ProviderData);

            var updatePayload = new UpdateAgreementRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new OneflowUpdateAgreementProviderParameters
                {
                    DataFields = new[] {
                      new OneflowUpdateAgreementDataField
                      {
                          Id = "first-name",
                          Value = "August"
                      }
                    }
                }
            };
            var updateAgreementResponse = await _api.Agreement.V1.UpdateAgreement(updatePayload);
            AssertHttpNoContent(updateAgreementResponse);

            var publishPayload = new PublishAgreementRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new PublishOneflowAgreementParameters
                {
                    Subject = "Signa detta mannen!",
                    Message = "Inte alls en scam!"
                }
            };
            var publishAgreementResponse = await _api.Agreement.V1.PublishAgreement(publishPayload);
            AssertHttpNoContent(publishAgreementResponse);
        }

    }
}
