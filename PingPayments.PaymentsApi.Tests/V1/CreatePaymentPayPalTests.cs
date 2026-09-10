using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared.Enums;
using System;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class CreatePaymentPayPalTests
    {
        [Fact]
        public void CreatePayment_PayPal_Ppcp_sets_provider_and_method()
        {
            var payment = CreatePayment.PayPal.Ppcp
            (
                CurrencyEnum.SEK,
                new[] { new OrderItem(100, "Item", 25m, Guid.NewGuid()) },
                description: "Order #123",
                designatedMerchantId: Guid.NewGuid(),
                itemCategory: PayPalItemCategoryEnum.DIGITAL_GOODS,
                locale: "sv-SE",
                redirectUrl: new Uri("https://example.com/redirect"),
                shipping: new PayPalShipping { Preference = PayPalShippingPreferenceEnum.NO_SHIPPING }
            );

            Assert.Equal(ProviderEnum.paypal, payment.Provider);
            Assert.Equal(MethodEnum.ppcp, payment.Method);
            Assert.IsType<PayPalPPCPPaymentParameters>(payment.ProviderMethodParameters);
        }
    }
}
