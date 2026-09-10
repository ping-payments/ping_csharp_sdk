using PingPayments.PaymentsApi.PaymentConsents.Create.V1;
using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request;
using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared.Enums;
using PingPayments.Tests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentConsentResourceTests : PaymentsApiTestClient
    {
        [Fact(Skip = "Sandbox/provider dependent payment consent signing flow returns 403 in current test environment")]
        public async Task Initiate_swish_recurring_payment_consent_without_qr_200()
        {
            var request = CreatePaymentConsent.Swish.Recurring(
                flow: "m_commerce",
                tin: "199311219639",
                signee: CreateSignee(),
                statusCallbackUrl: TestData.FakeCallback,
                metadata: new Dictionary<string, dynamic>());

            var response = await _api.PaymentConsent.V1.Create(request);

            AssertSuccessful(response);
            var body = response?.Body?.SuccessfulResponseBody as SwishRecurringConsentResponseBody;
            Assert.NotNull(body);
            Assert.NotEqual(Guid.Empty, body?.Id);
            Assert.False(string.IsNullOrWhiteSpace(body?.ProviderMethodResponse?.SwishUrl ?? body?.ProviderMethodResponse?.Url));
        }

        [Fact(Skip = "Sandbox/provider dependent payment consent signing flow returns 403 in current test environment")]
        public async Task Initiate_swish_recurring_payment_consent_with_qr_200()
        {
            var request = CreatePaymentConsent.Swish.Recurring(
                flow: "m_commerce",
                tin: "199311219639",
                signee: CreateSignee(),
                swishQrCode: new SwishQrCode(),
                statusCallbackUrl: TestData.FakeCallback,
                metadata: new Dictionary<string, dynamic>());

            var response = await _api.PaymentConsent.V1.Create(request);

            AssertSuccessful(response);
            var body = response?.Body?.SuccessfulResponseBody as SwishRecurringConsentResponseBody;
            Assert.NotNull(body);
            Assert.NotEqual(Guid.Empty, body?.Id);
            Assert.False(string.IsNullOrWhiteSpace(body?.ProviderMethodResponse?.QrCode));
        }

        [Fact]
        public async Task Initiate_bankgirot_autogiro_payment_consent_and_get_status_200()
        {
            var request = CreatePaymentConsent.Bankgirot.Autogiro(
                flow: "redirect",
                accountHolder: new LegalEntity
                {
                    Country = "SE",
                    Identifier = "199311219639",
                    Type = LegalEntityEnum.person
                },
                cancelUrl: new Uri("https://example.com/cancel"),
                errorUrl: new Uri("https://example.com/error"),
                locale: "sv-SE",
                mandateDescription: "Autogiro mandate",
                successUrl: new Uri("https://example.com/success"),
                signee: CreateSignee(),
                statusCallbackUrl: TestData.FakeCallback,
                metadata: new Dictionary<string, dynamic>());

            var createResponse = await _api.PaymentConsent.V1.Create(request);

            AssertSuccessful(createResponse);
            var createdConsent = createResponse?.Body?.SuccessfulResponseBody as BankgirotAutogiroConsentResponseBody;
            Assert.NotNull(createdConsent);
            Assert.NotEqual(Guid.Empty, createdConsent?.Id);

            var getResponse = await _api.PaymentConsent.V1.Get(createdConsent!.Id);

            AssertHttpOK(getResponse);
            var paymentConsent = getResponse.Body?.SuccessfulResponseBody;
            Assert.NotNull(paymentConsent);
            Assert.Equal(createdConsent.Id, paymentConsent?.Id);
            Assert.Equal(ProviderEnum.bankgirot, paymentConsent?.Provider);
            Assert.Equal(MethodEnum.autogiro, paymentConsent?.Method);
            Assert.True(Enum.IsDefined(typeof(PingPayments.PaymentsApi.PaymentConsents.Get.V1.PaymentConsentStatusEnum), paymentConsent!.Status));
        }

        [Fact]
        public async Task Initiate_swish_recurring_payment_consent_invalid_flow_422()
        {
            var request = new CreatePaymentConsentRequest(
                flow: "invalid",
                provider: ProviderEnum.swish,
                method: MethodEnum.recurring,
                providerMethodParameters: new SwishRecurringConsentParameters("199311219639", "0701234567"),
                signee: CreateSignee(),
                statusCallbackUrl: TestData.FakeCallback,
                metadata: new Dictionary<string, dynamic>());

            var response = await _api.PaymentConsent.V1.Create(request);

            AssertHttpUnprocessableEntity(response);
        }

        private static void AssertSuccessful(CreatePaymentConsentResponse response)
        {
            if ((int)response.StatusCode == 201)
            {
                AssertHttpCreated(response);
                return;
            }

            AssertHttpOK(response);
        }

        private static Payer CreateSignee() =>
            new(
                email: "john.doe@mail.com",
                ipAddress: "192.168.1.1",
                name: "John Doe",
                phoneNumber: "0701234567",
                payerAddress: new PayerAddress(
                    city: "Stockholm",
                    country: "SE",
                    county: "Stockholms län",
                    postalCode: "12345",
                    street: "Storgatan 1"),
                identity: new LegalEntity
                {
                    Country = "SE",
                    Identifier = "199311219639",
                    Type = LegalEntityEnum.person
                },
                sourceOfFunds: new[]
                {
                    SourceOfFundsEnum.salary_or_employment_income
                });
    }
}
