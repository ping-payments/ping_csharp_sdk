using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsApiSdk.Tests
{
    public class PaymentOrderEndpointsTests : BaseEndpointsTests
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.PaymentOrder.Get(TestData.OrderId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order()
        {
            var response = await _api.PaymentOrder.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task Can_create_order_without_split_tree_id()
        {
            var response = await _api.PaymentOrder.Create();
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Can_create_order_with_split_tree_id()
        {
            var response = await _api.PaymentOrder.Create(TestData.SplitTreeId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Can_update_order_with_split_tree_id()
        {
            var response = await _api.PaymentOrder.Update
            ((
                TestData.OrderId,
                TestData.SplitTreeId
            ));
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task List_returns_200_without_filter()
        {
            var response = await _api.PaymentOrder.List();
            AssertHttpOK(response);
        }

        [Fact]
        public async Task List_returns_200_with_filter()
        {
            var from = new DateTimeOffset(2022, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddMonths(6);
            var response = await _api.PaymentOrder.List((from, to));
            AssertHttpOK(response);
            Assert.True(response?.Body?.SuccesfulResponseBody?.PaymentOrders?.Any());
        }

        [Fact]
        public async Task Can_close_then_split_then_settle_an_order()
        {
            //1. Create order
            Guid orderId = await _api.PaymentOrder.Create();

            //2. Create payment
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
                1000,
                new OrderItem[]
                {
                    new OrderItem(1000, "A", 0.25m, Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d")),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }

            );
            var _ = await _api.Payments.Initiate(orderId, requestObject);
            
            //3. Close
            var closeResponse = await _api.PaymentOrder.Close(orderId);
            AssertHttpNoContent(closeResponse);

            //4. Split
            var splitResponse = await _api.PaymentOrder.Split(orderId);
            AssertHttpNoContent(splitResponse);

            //5. Settle 
            var settleResponse = await _api.PaymentOrder.Settle(orderId);
            AssertHttpNoContent(settleResponse);
        }
    }
}
