using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentsResourceTests : BaseResourceTests
    {
        [Fact]
        public async Task Initiate_payment_200()
        {
            var requestObject = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                TestData.FakeCallback
            );
            var response = await _api.Payments.V1.Initiate(TestData.OrderId, requestObject);
            AssertHttpOK(response);
            Assert.NotNull(response?.Body?.SuccesfulResponseBody);
            DummyResponseBody? body = response;
            Assert.NotNull(body);            
            Assert.NotEqual(Guid.Empty, body?.Id);
        }

        [Fact]
        public async Task Initiate_payment_422_when_order_items_and_total_amount_does_not_match()
        {
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
                1000,
                new OrderItem[]
                {
                    new OrderItem(500, "A", SwedishVat.Vat25, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                TestData.FakeCallback,
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await _api.Payments.V1.Initiate(TestData.OrderId, requestObject);
            AssertHttpUnprocessableEntity(response);
        }


        [Fact]
        public async Task Initiate_payment_404_when_order_id_does_not_exist()
        {
            var orderId = Guid.NewGuid();
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
               1000,
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                TestData.FakeCallback,
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await _api.Payments.V1.Initiate(orderId, requestObject);
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_works()
        {
            var response = await _api.Payments.V1.Get(TestData.OrderId, TestData.PaymentId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_404_on_wrong_payment_id()
        {
            var response = await _api.Payments.V1.Get(TestData.OrderId, Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order()
        {
            var response = await _api.Payments.V1.Get(Guid.NewGuid(), Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order_with_existing_payment()
        {
            var response = await _api.Payments.V1.Get(Guid.NewGuid(), TestData.PaymentId);
            AssertHttpNotFound(response);
        }


        [Fact]
        public async Task Initiate_ecommerce_swish_payment_200()
        {
            var request = CreatePayment.Swish.Ecommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "0701234567",
                "message",
                TestData.FakeCallback,
                new Dictionary<string, object> { });


            var response = await _api.Payments.V1.Initiate(TestData.OrderId, request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Initiate_mcommerce_swish_payment_with_qr_200()
        {
            var request = CreatePayment.Swish.Mcommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "message",
                TestData.FakeCallback,
                new SwishQrCode(),
                new Dictionary<string, object> { });


            var response = await _api.Payments.V1.Initiate(TestData.OrderId, request);
            
            AssertHttpOK(response);

            var mcommerceResponse = response?.Body?.SuccesfulResponseBody as SwishMCommerceResponseBody;
            Assert.False(string.IsNullOrEmpty(mcommerceResponse?.ProviderMethodResponse.QrCode));



        }

        [Fact]
        public async Task Initiate_mcommerce_swish_payment_without_qr_200()
        {
            var request = CreatePayment.Swish.Mcommerce(
                new OrderItem[]
                {
                    new OrderItem(5.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId),
                    new OrderItem(5.ToMinorCurrencyUnit(), "B", SwedishVat.Vat12, TestData.MerchantId),
                },
                "message",
                TestData.FakeCallback,
                null,
                new Dictionary<string, object> { });


            var response = await _api.Payments.V1.Initiate(TestData.OrderId, request);
            AssertHttpOK(response);
        }
    }
}
