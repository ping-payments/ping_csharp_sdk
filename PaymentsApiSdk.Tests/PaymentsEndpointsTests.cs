using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Initiate.Response;
using PaymentsApiSdk.Payments.Shared;
using PaymentsApiSdk.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsApiSdk.Tests
{
    public class PaymentsEndpointsTests
    {
        [Fact]
        public async Task Initiate_payment_200()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4");
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
                1000,
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m, Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d")),
                    new OrderItem(500, "B", 0.12m, Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d")),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }

            );
            var response = await api.Payments.Initiate(orderId, requestObject);
            
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.Null(response.Body.ErrorResponseBody);
            InitiatePaymentResponseBody body = response.Body.SuccesfulResponseBody;
            Assert.NotNull(body);            
            Assert.True(body.Id != Guid.Empty);
            Assert.Null(body.Billmate);
            Assert.Null(body.Verifone);
            Assert.Null(body.Swish);
        }

        [Fact]
        public async Task Initiate_payment_422_when_order_items_and_total_amount_does_not_match()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4");
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
                1000,
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m, Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d")),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await api.Payments.Initiate(orderId, requestObject);
            Assert.NotNull(response);
            Assert.Equal(422, response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.NotNull(response.Body.ErrorResponseBody);
            ErrorResponseBody body = response.Body.ErrorResponseBody;
            Assert.NotNull(body);
            Assert.True(body.Errors.Any());
            Assert.NotNull(body.Errors[0].Description);
            Assert.NotNull(body.Errors[0].Error);
            Assert.NotNull(body.Errors[0].Property);
        }


        [Fact]
        public async Task Initiate_payment_404_when_order_id_does_not_exist()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.NewGuid();
            var requestObject = new InitiatePaymentRequest
            (
                CurrencyEnum.SEK,
               1000,
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m, Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d")),
                    new OrderItem(500, "B", 0.12m, Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d")),
                },
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com"),
                new Dictionary<string, object> { { "test_data", 1337m } }
            );
            var response = await api.Payments.Initiate(orderId, requestObject);
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.NotNull(response.Body.ErrorResponseBody);
            ErrorResponseBody body = response.Body.ErrorResponseBody;
            Assert.NotNull(body);
            Assert.True(body.Errors.Any());
            Assert.NotNull(body.Errors[0].Description);
            Assert.NotNull(body.Errors[0].Error);
            Assert.Null(body.Errors[0].Property);
        }

        [Fact]
        public async Task Get_works()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4");
            var paymentId = Guid.Parse("cfc45f5f-2ec5-478c-8ec4-71410da43be1");
            var response = await api.Payments.Get(orderId, paymentId);
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task Get_404_on_wrong_payment_id()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var orderId = Guid.Parse("fb27904a-f274-4c9a-b14d-085583fbaad4");
            var response = await api.Payments.Get(orderId, Guid.NewGuid());
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
            //Assert.True(response.IsFailure);
            //Assert.False(response.IsSuccessful);
            //Assert.Null(response.Body);
            //Assert.NotNull(response.Body.ErrorResponseBody);
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
            var response = await api.Payments.Get(orderId, Guid.NewGuid());
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
            //Assert.True(response.IsFailure);
            //Assert.False(response.IsSuccessful);
            //Assert.Null(response.Body);
            //Assert.NotNull(response.Body.ErrorResponseBody);
        }
    }
}
