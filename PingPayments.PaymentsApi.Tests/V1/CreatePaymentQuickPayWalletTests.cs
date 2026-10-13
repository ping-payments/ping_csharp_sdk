using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class CreatePaymentQuickPayWalletTests
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            Converters =
            {
                new MethodEnumJsonConvert(),
                new JsonStringEnumConverter(),
                new ProviderMethodParametersJsonConvert(),
            },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        [Fact]
        public void CreatePayment_QuickPay_ApplePay_sets_provider_method_and_token()
        {
            var merchantId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000");
            var token = new Dictionary<string, dynamic>
            {
                ["paymentData"] = new Dictionary<string, dynamic> { ["version"] = "EC_v1" }
            };
            var payment = CreatePayment.QuickPay.ApplePay
            (
                CurrencyEnum.SEK,
                new[] { new OrderItem(100, "Item", 25m, merchantId) },
                merchantId,
                token
            );

            Assert.Equal(ProviderEnum.quickpay, payment.Provider);
            Assert.Equal(MethodEnum.apple_pay, payment.Method);
            Assert.IsType<QuickPayApplePayParameters>(payment.ProviderMethodParameters);

            using var body = JsonDocument.Parse(JsonSerializer.Serialize(payment, Options));
            Assert.Equal("apple_pay", body.RootElement.GetProperty("method").GetString());
            var parameters = body.RootElement.GetProperty("provider_method_parameters");
            Assert.Equal(merchantId.ToString(), parameters.GetProperty("designated_merchant_id").GetString());
            Assert.Equal("EC_v1", parameters.GetProperty("apple_pay_token").GetProperty("paymentData").GetProperty("version").GetString());
            Assert.False(parameters.TryGetProperty("provider_method", out _));
        }

        [Fact]
        public void CreatePayment_QuickPay_GooglePay_sets_provider_method_and_token()
        {
            var merchantId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000");
            var payment = CreatePayment.QuickPay.GooglePay
            (
                CurrencyEnum.SEK,
                new[] { new OrderItem(100, "Item", 25m, merchantId) },
                merchantId,
                "google-pay-token"
            );

            Assert.Equal(ProviderEnum.quickpay, payment.Provider);
            Assert.Equal(MethodEnum.google_pay, payment.Method);
            Assert.IsType<QuickPayGooglePayParameters>(payment.ProviderMethodParameters);

            using var body = JsonDocument.Parse(JsonSerializer.Serialize(payment, Options));
            Assert.Equal("google_pay", body.RootElement.GetProperty("method").GetString());
            var parameters = body.RootElement.GetProperty("provider_method_parameters");
            Assert.Equal(merchantId.ToString(), parameters.GetProperty("designated_merchant_id").GetString());
            Assert.Equal("google-pay-token", parameters.GetProperty("google_pay_token").GetString());
            Assert.False(parameters.TryGetProperty("provider_method", out _));
        }
    }
}
