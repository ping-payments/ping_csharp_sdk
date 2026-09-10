using PingPayments.PaymentsApi.PaymentConsents.Create.V1;
using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request;
using PingPayments.PaymentsApi.PaymentConsents.Create.V1.Response;
using PingPayments.PaymentsApi.PaymentConsents.Get.V1;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentConsentResponseTests
    {
        [Fact]
        public async Task Can_parse_swish_recurring_payment_consent() =>
            Assert.True
            (
                await CreatePaymentConsentOperation.GetResponseBody
                (
                    ProviderEnum.swish,
                    MethodEnum.recurring,
                    "{\"id\":\"15c44587-7ebb-43a3-b437-8d00e5f8df7a\",\"provider_method_response\":{\"payment_request_token\":\"-P3RvSYrQQqNFhY3lyFgBy6hCg1qFGdz\",\"qr_code\":null,\"swish_url\":\"swish://paymentrequest?token=c28a4061470f4af48973bd2a4642b4fa&callbackurl=merchant%253A%252F%252F\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() } }
                ) is SwishRecurringConsentResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse?.PaymentRequestToken) &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse?.SwishUrl)
            );

        [Fact]
        public async Task Can_parse_bankgirot_autogiro_payment_consent() =>
            Assert.True
            (
                await CreatePaymentConsentOperation.GetResponseBody
                (
                    ProviderEnum.bankgirot,
                    MethodEnum.autogiro,
                    "{\"id\":\"9fa232ba-41e0-4f39-bc8a-7dd07337e3b4\",\"provider_method_response\":{\"sign_url\":\"https://ais-sandbox.pingpayments.com/mM0BHDLM\"}}",
                    new() { Converters = { new MethodEnumJsonConvert(), new JsonStringEnumConverter(), new ProviderMethodParametersJsonConvert() } }
                ) is BankgirotAutogiroConsentResponseBody x &&
                !string.IsNullOrWhiteSpace(x.ProviderMethodResponse?.SignUrl)
            );

        [Fact]
        public void Can_parse_payment_consent_get_response()
        {
            var json = "{\"id\":\"9fa232ba-41e0-4f39-bc8a-7dd07337e3b4\",\"created_at\":\"2024-01-01T12:00:00Z\",\"method\":\"autogiro\",\"provider\":\"bankgirot\",\"signee\":{\"name\":\"John Doe\"},\"status\":\"INITIATED\"}";
            var result = JsonSerializer.Deserialize<PaymentConsent>(json, new JsonSerializerOptions
            {
                Converters =
                {
                    new MethodEnumJsonConvert(),
                    new JsonStringEnumConverter()
                }
            });

            Assert.NotNull(result);
            Assert.Equal(System.Guid.Parse("9fa232ba-41e0-4f39-bc8a-7dd07337e3b4"), result!.Id);
            Assert.Equal(ProviderEnum.bankgirot, result.Provider);
            Assert.Equal(MethodEnum.autogiro, result.Method);
            Assert.Equal(PaymentConsentStatusEnum.INITIATED, result.Status);
        }
    }
}
