using System;
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
    }
}
