﻿using PingPayments.KYC.Agreement.V1.Create;
using PingPayments.KYC.Agreement.V1.Create.Oneflow;
using PingPayments.KYC.Agreement.V1.CreateAccessLink;
using PingPayments.KYC.Agreement.V1.CreateAccessLink.Oneflow;
using PingPayments.KYC.Agreement.V1.Get;
using PingPayments.KYC.Agreement.V1.Get.Oneflow;
using PingPayments.KYC.Agreement.V1.Publish;
using PingPayments.KYC.Agreement.V1.Publish.Oneflow;
using PingPayments.KYC.Agreement.V1.Shared;
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
            var agreementResponse = await _api.Agreement.V1.ListTemplates();
            AssertHttpOK(agreementResponse);

            var templateId = agreementResponse.Body.SuccessfulResponseBody.First().Id;

            var createAgreementRequest = new Agreement.V1.Create.CreateRequestBody
            {
                TemplateId = templateId,
                MerchantId = TestData.MerchantId,
                Name = "Test",
                Provider = AgreementTypeEnum.oneflow,
                ProviderParameters = new Agreement.V1.Create.Oneflow.ProviderParameters
                {
                    Party = new Organization
                    {
                        Country = CountryEnum.SE,
                        Identity = "559171-1873",
                        Name = "RaJo Software AB",
                        SubParties = new List<Subparty>
                        {
                            new Subparty
                            {
                                Identity = "199201154953",
                                Name = "Johannes Norrbacka",
                                Email = "johannes@monetax.se",
                                Country = CountryEnum.SE,
                                Editor = true,
                                PhoneNumber = "46701234567",
                                Signatory = true,
                                SignMethod = SignMethodEnum.standard_esign,
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

            Contract providerData = (Contract)getAgreementResponse.Body.SuccessfulResponseBody.ProviderData;
            var participantId = providerData.Participants[1].Id;

            AgreementResponseBody agreement = getAgreementResponse.Body.SuccessfulResponseBody;
            Assert.NotNull(agreement.ProviderData);

            var updatePayload = new UpdateRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new UpdateAgreementProviderParameters
                {
                    DataFields = new[] {
                      new UpdateAgreementDataField
                      {
                          Id = "first-name",
                          Value = "August"
                      }
                    }
                }
            };
            var updateAgreementResponse = await _api.Agreement.V1.Update(updatePayload);
            AssertHttpNoContent(updateAgreementResponse);

            var publishPayload = new PublishRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new PublishAgreementParameters
                {
                    Subject = "Signa detta mannen!",
                    Message = "Inte alls en scam!"
                }
            };
            var publishAgreementResponse = await _api.Agreement.V1.Publish(publishPayload);
            AssertHttpNoContent(publishAgreementResponse);

            var accessLinkPayload = new Agreement.V1.CreateAccessLink.CreateRequestBody
            {
                AgreementId = agreementId,
                ProviderParameters = new CreateAgreementAccessLinkParameters
                {
                    ParticipantId = participantId,
                }
            };
            var createAccessLinkResponse = await _api.Agreement.V1.CreateAccessLink(accessLinkPayload);
            AssertHttpOK(createAccessLinkResponse);
        }


        [Fact]
        public async Task Verify_a_full_agreement_flow_for_person()
        {
            var agreementResponse = await _api.Agreement.V1.ListTemplates();
            AssertHttpOK(agreementResponse);

            var templateId = agreementResponse.Body.SuccessfulResponseBody.First().Id;

            var createAgreementRequest = new Agreement.V1.Create.CreateRequestBody
            {
                TemplateId = templateId,
                MerchantId = TestData.MerchantId,
                Name = "Test",
                Provider = AgreementTypeEnum.oneflow,
                ProviderParameters = new Agreement.V1.Create.Oneflow.ProviderParameters
                {
                    Party = new Person
                    {
                        Identity = "199201154953",
                        Name = "Johannes Norrbacka",
                        Email = "johannes@monetax.se",
                        Country = CountryEnum.SE,
                        Editor = true,
                        PhoneNumber = "46701234567",
                        Signatory = true,
                        SignMethod = SignMethodEnum.standard_esign
                    }
                }
            };
            var createAgreementResponse = await _api.Agreement.V1.Create(createAgreementRequest);
            AssertHttpOK(createAgreementResponse);

            var agreementId = createAgreementResponse.Body.SuccessfulResponseBody.Id;
            var getAgreementResponse = await _api.Agreement.V1.Get(agreementId);
            AssertHttpOK(getAgreementResponse);

            Contract providerData = (Contract)getAgreementResponse.Body.SuccessfulResponseBody.ProviderData;
            var participantId = providerData.Participants[1].Id;

            AgreementResponseBody agreement = getAgreementResponse.Body.SuccessfulResponseBody;
            Assert.NotNull(agreement.ProviderData);

            var updatePayload = new UpdateRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new UpdateAgreementProviderParameters
                {
                    DataFields = new[] {
                      new UpdateAgreementDataField
                      {
                          Id = "first-name",
                          Value = "August"
                      }
                    }
                }
            };
            var updateAgreementResponse = await _api.Agreement.V1.Update(updatePayload);
            AssertHttpNoContent(updateAgreementResponse);

            var publishPayload = new PublishRequest
            {
                AgreementId = agreementId,
                ProviderParameters = new PublishAgreementParameters
                {
                    Subject = "Signa detta mannen!",
                    Message = "Inte alls en scam!"
                }
            };
            var publishAgreementResponse = await _api.Agreement.V1.Publish(publishPayload);
            AssertHttpNoContent(publishAgreementResponse);

            var accessLinkPayload = new Agreement.V1.CreateAccessLink.CreateRequestBody
            {
                AgreementId = agreementId,
                ProviderParameters = new CreateAgreementAccessLinkParameters
                {
                    ParticipantId = participantId,
                }
            };
            var createAccessLinkResponse = await _api.Agreement.V1.CreateAccessLink(accessLinkPayload);
            AssertHttpOK(createAccessLinkResponse);
        }

    }
}
