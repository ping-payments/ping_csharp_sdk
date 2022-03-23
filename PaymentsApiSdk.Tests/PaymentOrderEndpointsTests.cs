using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsApiSdk.Tests
{
    public class PaymentOrderEndpointsTests
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4");
            var response = await api.PaymentOrder.Get(orderId);
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task Get_404_on_non_existing_order()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.NewGuid();
            var response = await api.PaymentOrder.Get(orderId);
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.IsSuccessful);
            Assert.Null(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task Can_create_order_without_split_tree_id()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var response = await api.PaymentOrder.Create();
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task Can_create_order_with_split_tree_id()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var response = await api.PaymentOrder.Create(Guid.Parse("5802e367-96dd-4cc8-b0de-b4603fb6a32d"));
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task Can_update_order_with_split_tree_id()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var response = await api.PaymentOrder.Update
            ((
                Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4"),
                Guid.Parse("5802e367-96dd-4cc8-b0de-b4603fb6a32d")
            ));
            Assert.NotNull(response);
            Assert.Equal(204, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task List_returns_200_without_filter()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var response = await api.PaymentOrder.List();
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.True(response.Body.SuccesfulResponseBody.PaymentOrders.Any());
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task List_returns_200_with_filter()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var from = new DateTimeOffset(2022, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddMonths(6);
            var response = await api.PaymentOrder.List((from, to));
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.True(response.Body.SuccesfulResponseBody.PaymentOrders.Any());
            Assert.Null(response.Body.ErrorResponseBody);
        }
    }
}
