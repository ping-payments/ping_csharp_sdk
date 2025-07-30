using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Shared.Helpers;
using PingPayments.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentOrderResourceTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.PaymentOrder.V1.Get(TestData.OrderId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order()
        {
            var response = await _api.PaymentOrder.V1.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }


        [Fact]
        public async Task Can_create_order_with_split_parameters()
        {
            var splitParameters = new Dictionary<string, object> { { "tenant_fee", 20.ToMinorCurrencyUnit() } };
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK, SplitParamters: splitParameters);
            var response = await _api.PaymentOrder.V1.Create(request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Can_create_order_with_split_tree_id()
        {
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK, SplitTreeId: TestData.SplitTreeId);
            var response = await _api.PaymentOrder.V1.Create(request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Can_create_order_with_split_tree_id_and_split_paramters()
        {
            dynamic splitParameters = new { tenant_fee = 20.ToMinorCurrencyUnit() };
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK, splitParameters, TestData.SplitTreeId);
            var response = await _api.PaymentOrder.V1.Create(request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Can_create_order_without_split_tree_id_and_split_paramters()
        {
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
            var response = await _api.PaymentOrder.V1.Create(request);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Can_update_order_with_split_tree_id_and_split_parameters()
        {
            dynamic splitParameters = new { tenant_fee = 20.ToMinorCurrencyUnit() };
            var updateRequest = new UpdatePaymentOrderRequest
            (
                SplitParamters: splitParameters,
                SplitTreeId: TestData.SplitTreeId
            );

            var response = await _api.PaymentOrder.V1.Update
            (
                TestData.OrderId,
                updateRequest
            );
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task List_Data_returns_200_without_filter()
        {
            var response = await _api.PaymentOrder.V1.ListData();
            AssertHttpOK(response);
            PaymentOrder[] orders = response;
            Assert.True(orders.Any());
        }

        [Fact]
        public async Task List_Data_returns_200_with_filter()
        {
            var from = new DateTimeOffset(2022, 10, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddDays(60);

            var response = await _api.PaymentOrder.V1.ListData(from, to);
            AssertHttpOK(response);
            PaymentOrder[] orders = response;
            Assert.True(orders.Any());
        }

        [Fact]
        public async Task List_Data_returns_200_with_filter_Status()
        {
            var from = new DateTimeOffset(2022, 10, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddDays(60);

            var response = await _api.PaymentOrder.V1.ListData(from, to, PaymentOrderStatusEnum.SETTLED);
            AssertHttpOK(response);
            PaymentOrder[] orders = response;
            Assert.True(orders.Any());
        }
        

        [Fact]
        public async Task List_Page_returns_200()
        {
            var from = new DateTimeOffset(2022, 10, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddDays(60);

            var response = await _api.PaymentOrder.V1.ListPage(from, to, PaymentOrderStatusEnum.SETTLED);
            AssertHttpOK(response);
            PaymentOrder[] orders = response;
            Assert.True(orders.Any());
            PaginationLinks pages = response;
            Assert.NotEmpty(pages?.Current?.Href);
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        [Fact]
        public async Task Can_close_then_split_then_settle_an_order()
        {

            //1. Prepare a order
            var idTuple = PreparePaymentOrder();
            Guid paymentId = idTuple.Result.paymentId;
            Guid orderId = idTuple.Result.orderId;

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            //3. Close
            AssertHttpNoContent(await _api.PaymentOrder.V1.Close(orderId));

            //4. Split
            AssertHttpNoContent(await _api.PaymentOrder.V1.Split(orderId));

            //5. Settle 
            AssertHttpNoContent(await _api.PaymentOrder.V1.Settle(orderId));
        }

        [Fact]
        public async Task Can_not_split_before_close_403()
        {
            //1. Prepare a order
            var idTuple = PreparePaymentOrder();
            Guid paymentId = idTuple.Result.paymentId;
            Guid orderId = idTuple.Result.orderId;

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            // Split an open order
            AssertHttpApiError(await _api.PaymentOrder.V1.Split(orderId));
        }

        [Fact]
        public async Task Can_not_settle_before_close_403()
        {
            //1. Prepare a order
            var idTuple = PreparePaymentOrder();
            Guid paymentId = idTuple.Result.paymentId;
            Guid orderId = idTuple.Result.orderId;

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            // Settle an open order
            AssertHttpApiError(await _api.PaymentOrder.V1.Settle(orderId));
        }

        [Fact]
        public async Task Can_not_settle_before_split_403()
        {
            //1. Prepare a order
            var idTuple = PreparePaymentOrder();
            Guid paymentId = idTuple.Result.paymentId;
            Guid orderId = idTuple.Result.orderId;

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            //3. Close
            await _api.PaymentOrder.V1.Close(orderId);
            //4. Settle without split
            AssertHttpApiError(await _api.PaymentOrder.V1.Settle(orderId));
        }

        [Fact]
        public async Task Can_fast_forward_to_settle()
        {
            //1. Prepare a order
            var idTuple = PreparePaymentOrder();
            Guid paymentId = idTuple.Result.paymentId;
            Guid orderId = idTuple.Result.orderId;

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            //3. fast forward to settle
            AssertHttpNoContent(await _api.PaymentOrder.V1.Settle(orderId, true));
        }

        [Fact]
        public async Task Can_fast_forward_to_split()
        {
            //1. Prepare a order
            var idTuple = PreparePaymentOrder();
            Guid paymentId = idTuple.Result.paymentId;
            Guid orderId = idTuple.Result.orderId;

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            //3. fast forward to split
            AssertHttpNoContent(await _api.PaymentOrder.V1.Split(orderId, true));
        }


        [Fact]
        public async Task Can_fetch_allocations_after_split()
        {
            //1. Prepare a order
            var (orderId, paymentId) = await PreparePaymentOrder();

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            //3. Close
            AssertHttpNoContent(await _api.PaymentOrder.V1.Close(orderId));

            //4. Split
            AssertHttpNoContent(await _api.PaymentOrder.V1.Split(orderId));

            var allocationsResponse = await _api.Allocation.V1.ListData(paymentOrderId: orderId);

            AssertHttpOK(allocationsResponse);
        }

        [Fact]
        public async Task Cant_fetch_allocations_on_order_which_has_not_been_split()
        {
            //1. Prepare a order
            var (orderId, paymentId) = await PreparePaymentOrder();

            //2. Await payment
            await AwaitPaymentCallback(orderId, paymentId);

            //3. Close
            AssertHttpNoContent(await _api.PaymentOrder.V1.Close(orderId));

            //4. Split

            var allocationsResponse = await _api.Allocation.V1.ListData(paymentOrderId: orderId);

            AssertHttpApiError(allocationsResponse);

        }

        public async Task<(Guid orderId, Guid paymentId)> PreparePaymentOrder()
        {
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
            Guid orderId = await _api.PaymentOrder.V1.Create(request);

            //2. Create payment
            var requestObject = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem(10.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId).InList(),
                TestData.FakeCallback
            );
            InitiatePaymentResponse paymentResponse = await _api.Payments.V1.Initiate(orderId, requestObject);
            Guid paymentId = paymentResponse.Body.SuccessfulResponseBody.Id;
            return (orderId, paymentId);
        }

        public async Task AwaitPaymentCallback(Guid orderId, Guid paymentId)
        {
            bool isStatusCompleted = false;
            while (!isStatusCompleted)
            {
                PaymentResponse payment = await _api.Payments.V1.Get(orderId, paymentId);
                var paymentStatus = payment.Body.SuccessfulResponseBody.Status;

                if (paymentStatus == PaymentStatusEnum.COMPLETED) isStatusCompleted = true;
            }
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
