using PingPayments.PaymentsApi.Payments.Initiate.Request;
using PingPayments.PaymentsApi.Payments.Initiate.Response;
using PingPayments.PaymentsApi.Payments.Shared;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests
{
    public class PaymentsEndpointsTests : BaseEndpointsTests
    {
        [Fact]
        public async Task Initiate_payment_200()
        {
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
                1000,
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m, TestData.MerchantId),
                    new OrderItem(500, "B", 0.12m, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }

            );
            var response = await _api.Payments.Initiate(TestData.OrderId, requestObject);
            AssertHttpOK(response);
            InitiatePaymentResponseBody? body = response.Body?.SuccesfulResponseBody;
            Assert.NotNull(body);            
            Assert.NotEqual(Guid.Empty, body?.Id);
            Assert.Null(body?.Billmate);
            Assert.Null(body?.Verifone);
            Assert.Null(body?.Swish);
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
                    new OrderItem(500, "A", 0.25m, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await _api.Payments.Initiate(TestData.OrderId, requestObject);
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
                    new OrderItem(500, "A", 0.25m, TestData.MerchantId),
                    new OrderItem(500, "B", 0.12m, TestData.MerchantId),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await _api.Payments.Initiate(orderId, requestObject);
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_works()
        {
            var response = await _api.Payments.Get(TestData.OrderId, TestData.PaymentId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_404_on_wrong_payment_id()
        {
            var response = await _api.Payments.Get(TestData.OrderId, Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order()
        {
            var response = await _api.Payments.Get(Guid.NewGuid(), Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order_with_existing_payment()
        {
            var response = await _api.Payments.Get(Guid.NewGuid(), TestData.PaymentId);
            AssertHttpNotFound(response);
        }
    }
}
