﻿using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Create.V1;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Get.V1;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared;
using PingPayments.PaymentsApi.KYC.AccountVerificationSession.Shared.Styling;
using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using PingPayments.PaymentsApi.Payments.Initiate.V1.Request;
using PingPayments.Tests;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class KYCTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Malformed_identity_create_verification_session_returns_400()
        {
            var payload = new CreateSessionRequest
            {
                AccountHolder = new LegalEntityIdentity
                {
                    Country = LegalEntityCountryEnum.SE,
                    Identifier = "",
                    Type = LegalEntityTypeEnum.person
                },
                MerchantId = TestData.MerchantId.ToString(),
                Options = new SessionOptions
                {
                    Locale = SupportedLocales.sv_SE
                }
            };

            var createResponse = await _api.AccountVerification.V1.Create(payload);
            AssertBadRequest(createResponse);
        }

        [Fact]
        public async Task Can_create_and_get_verification_session()
        {
            var payload = new CreateSessionRequest
            {
                AccountHolder = new LegalEntityIdentity
                {
                    Country = LegalEntityCountryEnum.SE,
                    Identifier = "200001011111",
                    Type = LegalEntityTypeEnum.person
                },
                MerchantId = TestData.MerchantId.ToString(),
                Options = new SessionOptions
                {
                    Locale = SupportedLocales.sv_SE,
                    Style = new Style
                    {
                        InvalidLinkModal = new Modal { BackgroundColor = "#3FFF33", TextColor = "#3FFF33", SubTextColor = "#3FFF33" },
                        SuccessModal = new Modal { BackgroundColor = "#3FFF33", TextColor = "#3FFF33", SubTextColor = "#3FFF33" },
                        CancelButton = new Button { BackgroundColor = "#3FFF33", TextColor = "#3FFF33", HoverColor = "#3FFF33" },
                        BackButton = new Button { BackgroundColor = "#3FFF33", TextColor = "#3FFF33", HoverColor = "#3FFF33" },
                        SearchBar = new SearchBar { BackgroundColor = "#3FFF33", TextColor = "#3FFF33" },
                        ListItem = new ListStyle { BackgroundColor = "3FFF33", HoverColor = "#3FFF33" },
                        SpinnerColor = "#3FFF33",
                        BackgroundColor = "#3FFF33",
                        ModalBackgroundColor = "#3FFF33",
                        TextColor = "#3FFF33",
                    }
                }
            };

            var createResponse = await _api.AccountVerification.V1.Create(payload);
            AssertHttpOK(createResponse);

            CreateSessionResponseBody createBody = createResponse.Body.SuccessfulResponseBody;
            Assert.NotEqual("", createBody.Id);
            Assert.NotNull(createBody.Id);
            Assert.NotNull(createBody.SessionVerificationUrl);
            Assert.NotEqual("", createBody.SessionVerificationUrl);

            var getResponse = await _api.AccountVerification.V1.Get(createBody.Id);
            AssertHttpOK(getResponse);

            GetSessionResponseBody getBody = getResponse.Body.SuccessfulResponseBody;
            Assert.NotEqual("", getBody.Id);
            Assert.NotNull(getBody.Id);
            Assert.NotEmpty(getBody.StatusHistory);
            Assert.NotNull(getBody.SessionUrl);

            Assert.Equal(createBody.Id, getBody.Id);
        }
    }
}

