using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1;
using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Request;
using PingPayments.PaymentsApi.Merchants.ActivatePaymentMethod.V1.Response;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class ActivatePaymentMethodTests
    {
        private static readonly Guid MerchantId = Guid.Parse("2d041d6d-21c9-4c65-96eb-5b9047732417");
        private static readonly Guid ActivationId = Guid.Parse("61a1053e-72d8-41f2-8246-d4c39958cb91");

        [Fact]
        public async Task Klarna_hpp_posts_json_with_onboarding_urls()
        {
            var handler = new CaptureHandler
            {
                ResponseJson = "{\"id\":\"61a1053e-72d8-41f2-8246-d4c39958cb91\",\"status\":\"PENDING\",\"provider_method_response\":{\"redirect_url\":\"https://klarna.example/onboard\"}}"
            };
            var operation = new ActivateKlarnaHPPOperation(Client(handler));
            var request = new ActivateKlarnaHPPRequest
            (
                new ActivateKlarnaHPPParameters(new Uri("https://example.com/success"), new Uri("https://example.com/cancel")),
                new Uri("https://example.com/callback")
            );

            var response = await operation.ExecuteRequest((MerchantId, request));

            Assert.Equal(HttpMethod.Post, handler.Request!.Method);
            Assert.EndsWith($"/api/v1/merchants/{MerchantId}/payment_provider_methods/activations", handler.Request.RequestUri!.AbsolutePath);
            Assert.Equal("application/json", handler.Request.Content!.Headers.ContentType!.MediaType);
            using var json = JsonDocument.Parse(handler.Body!);
            Assert.Equal("hpp", json.RootElement.GetProperty("method").GetString());
            Assert.Equal("klarna", json.RootElement.GetProperty("provider").GetString());
            Assert.Equal("https://example.com/callback", json.RootElement.GetProperty("status_callback_url").GetString());
            var parameters = json.RootElement.GetProperty("provider_method_parameters");
            Assert.Equal("https://example.com/success", parameters.GetProperty("success_url").GetString());
            Assert.Equal("https://example.com/cancel", parameters.GetProperty("cancel_url").GetString());
            Assert.False(parameters.GetProperty("use_existing_signed_klarna_agreement").GetBoolean());
            Assert.False(parameters.TryGetProperty("provider_method", out _));
            ActivateKlarnaHPPResponseBody? body = response;
            Assert.Equal(ActivationId, body!.Id);
            Assert.Equal(MerchantPaymentProviderMethodActivationStatusEnum.PENDING, body.Status);
            Assert.Equal("https://klarna.example/onboard", body.ProviderMethodResponse!.RedirectUrl);
        }

        [Fact]
        public async Task Klarna_hpp_from_existing_agreement_omits_urls()
        {
            var handler = new CaptureHandler();
            var operation = new ActivateKlarnaHPPOperation(Client(handler));
            var request = new ActivateKlarnaHPPRequest(ActivateKlarnaHPPParameters.FromExistingSignedAgreement());

            await operation.ExecuteRequest((MerchantId, request));

            using var json = JsonDocument.Parse(handler.Body!);
            var parameters = json.RootElement.GetProperty("provider_method_parameters");
            Assert.True(parameters.GetProperty("use_existing_signed_klarna_agreement").GetBoolean());
            Assert.False(parameters.TryGetProperty("success_url", out _));
            Assert.False(parameters.TryGetProperty("cancel_url", out _));
            Assert.False(json.RootElement.TryGetProperty("status_callback_url", out _));
        }

        [Fact]
        public async Task Quickpay_card_posts_email_and_omits_empty_address()
        {
            var handler = new CaptureHandler
            {
                ResponseJson = "{\"id\":\"61a1053e-72d8-41f2-8246-d4c39958cb91\",\"status\":\"COMPLETED\",\"provider_method_response\":{}}"
            };
            var operation = new ActivateQuickpayOperation(Client(handler));

            var response = await operation.ExecuteRequest
            ((
                MerchantId,
                ActivateQuickpayRequest.Card(new ActivateQuickpayParameters("merchant@example.com"))
            ));

            using var json = JsonDocument.Parse(handler.Body!);
            Assert.Equal("card", json.RootElement.GetProperty("method").GetString());
            Assert.Equal("quickpay", json.RootElement.GetProperty("provider").GetString());
            var parameters = json.RootElement.GetProperty("provider_method_parameters");
            Assert.Equal("merchant@example.com", parameters.GetProperty("email").GetString());
            Assert.False(parameters.TryGetProperty("address_line", out _));
            Assert.False(parameters.TryGetProperty("city", out _));
            Assert.False(parameters.TryGetProperty("postal_code", out _));
            ActivateQuickpayResponseBody? body = response;
            Assert.Equal(MerchantPaymentProviderMethodActivationStatusEnum.COMPLETED, body!.Status);
            Assert.NotNull(body.ProviderMethodResponse);
        }

        [Theory]
        [InlineData("apple_pay")]
        [InlineData("google_pay")]
        public async Task Quickpay_wallet_posts_method_and_address(string method)
        {
            var handler = new CaptureHandler();
            var operation = new ActivateQuickpayOperation(Client(handler));
            var parameters = new ActivateQuickpayParameters("merchant@example.com", "Storgatan 1", "Stockholm", "11122");
            var request = method == "apple_pay"
                ? ActivateQuickpayRequest.ApplePay(parameters)
                : ActivateQuickpayRequest.GooglePay(parameters);

            await operation.ExecuteRequest((MerchantId, request));

            using var json = JsonDocument.Parse(handler.Body!);
            Assert.Equal(method, json.RootElement.GetProperty("method").GetString());
            var body = json.RootElement.GetProperty("provider_method_parameters");
            Assert.Equal("Storgatan 1", body.GetProperty("address_line").GetString());
            Assert.Equal("Stockholm", body.GetProperty("city").GetString());
            Assert.Equal("11122", body.GetProperty("postal_code").GetString());
        }

        [Fact]
        public async Task Quickpay_vipps_posts_png_logo_as_multipart()
        {
            var handler = new CaptureHandler();
            var operation = new ActivateQuickpayVippsOperation(Client(handler));
            var request = new ActivateQuickpayVippsRequest
            (
                new ActivateQuickpayVippsParameters("merchant@example.com", PngLogo, "logo.png"),
                new Uri("https://example.com/callback")
            );

            await operation.ExecuteRequest((MerchantId, request));

            Assert.Equal("multipart/form-data", handler.Request!.Content!.Headers.ContentType!.MediaType);
            Assert.Contains("name=provider", handler.Body);
            Assert.Contains("quickpay", handler.Body);
            Assert.Contains("name=method", handler.Body);
            Assert.Contains("vipps", handler.Body);
            Assert.Contains("name=status_callback_url", handler.Body);
            Assert.Contains("https://example.com/callback", handler.Body);
            Assert.Contains("name=\"provider_method_parameters[email]\"", handler.Body);
            Assert.Contains("merchant@example.com", handler.Body);
            Assert.Contains("name=\"provider_method_parameters[logo]\"", handler.Body);
            Assert.Contains("filename=logo.png", handler.Body);
            Assert.Contains("image/png", handler.Body);
            Assert.DoesNotContain("address_line", handler.Body);
        }

        [Fact]
        public void Quickpay_vipps_rejects_a_logo_that_is_not_png()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
                new ActivateQuickpayVippsParameters("merchant@example.com", new byte[] { 1, 2, 3 }, "logo.png"));

            Assert.Equal("logo", exception.ParamName);
        }

        [Fact]
        public void Callback_deserializes_completed_status_with_null_details()
        {
            var callback = JsonSerializer.Deserialize<MerchantPaymentProviderMethodActivationCallback>
            (
                "{\"id\":\"61a1053e-72d8-41f2-8246-d4c39958cb91\",\"status\":\"COMPLETED\",\"details\":null}",
                new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } }
            );

            Assert.Equal(ActivationId, callback!.Id);
            Assert.Equal(MerchantPaymentProviderMethodActivationStatusEnum.COMPLETED, callback.Status);
            Assert.Null(callback.Details);
        }

        private static readonly byte[] PngLogo = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        private static HttpClient Client(CaptureHandler handler) =>
            new(handler) { BaseAddress = new Uri("https://example.test/") };

        private sealed class CaptureHandler : HttpMessageHandler
        {
            public HttpRequestMessage? Request { get; private set; }
            public string? Body { get; private set; }
            public string ResponseJson { get; set; } = "{\"id\":\"61a1053e-72d8-41f2-8246-d4c39958cb91\",\"status\":\"PENDING\",\"provider_method_response\":{}}";

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Request = request;
                Body = request.Content == null ? null : await request.Content.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ResponseJson, Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
