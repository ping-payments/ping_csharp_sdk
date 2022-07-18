using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PaymentOrderResourceTests : BaseResourceTests
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
            var splitParamters = new Dictionary<string, object> { { "tenant_fee", 20.ToMinorCurrencyUnit() } }; 
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK, SplitParamters: splitParamters);
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
            dynamic splitParamters = new { tenant_fee = 20.ToMinorCurrencyUnit() };
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK, splitParamters, TestData.SplitTreeId);
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
        public async Task Can_update_order_with_split_tree_id()
        {
            var response = await _api.PaymentOrder.V1.Update
            ((
                TestData.OrderId,
                TestData.SplitTreeId
            ));
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task List_returns_200_without_filter()
        {
            var response = await _api.PaymentOrder.V1.List();
            AssertHttpOK(response);
        }

        [Fact]
        public async Task List_returns_200_with_filter()
        {
            var from = new DateTimeOffset(2022, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddMonths(6);
            var response = await _api.PaymentOrder.V1.List((from, to));
            AssertHttpOK(response);
            PaymentOrder[] orders = response;
            Assert.True(orders.Any());
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        [Fact]
        public async Task Can_close_then_split_then_settle_an_order()
        {

            //1. Create order
            var request = new CreatePaymentOrderRequest(CurrencyEnum.SEK);
            Guid orderId = await _api.PaymentOrder.V1.Create(request);

            //2. Create payment
            var requestObject = CreatePayment.Dummy.New
            (
                CurrencyEnum.SEK,
                new OrderItem(10.ToMinorCurrencyUnit(), "A", SwedishVat.Vat25, TestData.MerchantId).InList(),
                TestData.FakeCallback
            );


            InitiatePaymentResponse paymentId = await _api.Payments.V1.Initiate(orderId, requestObject);

            bool isStatusCompleted = false;
            while (!isStatusCompleted)
            {
                PaymentResponse payment = await _api.Payments.V1.Get(orderId, paymentId.Body.SuccesfulResponseBody.Id);
                var paymentStatus = payment.Body.SuccesfulResponseBody.Status;

                if (paymentStatus == PaymentStatusEnum.COMPLETED) isStatusCompleted = true;
            }

            //3. Close
            AssertHttpNoContent(await _api.PaymentOrder.V1.Close(orderId));

            //4. Split
            AssertHttpNoContent(await _api.PaymentOrder.V1.Split(orderId));

            //5. Settle 
            AssertHttpNoContent(await _api.PaymentOrder.V1.Settle(orderId));
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}
