using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Initiate.Response;
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
        public async Task Can_create_a_payment()
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
                new Dictionary<Guid, int> {{ Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d"), 1000 }},
                new Dictionary<string, object> { { "test_data", 1337m } },
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m),
                    new OrderItem(500, "B", 0.12m),
                },
                MethodEnum.dummy,
                ProviderEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com")
            );
            var response = await api.Payments.InitiatePayment(orderId, requestObject);
            
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
        public async Task Can_handle_422_when_a_payment_body_is_wrong()
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
                new Dictionary<Guid, int> { { Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d"), 1000 } },
                new Dictionary<string, object> { { "test_data", 1337m } },
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m),
                    //new OrderItem(500, "B", 0.12m),
                },
                MethodEnum.dummy,
                ProviderEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com")
            );
            var response = await api.Payments.InitiatePayment(orderId, requestObject);
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
        public async Task Can_handle_404_when_a_payment_order_does_not_exist()
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
                new Dictionary<Guid, int> { { Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d"), 1000 } },
                new Dictionary<string, object> { { "test_data", 1337m } },
                new OrderItem[]
                {
                    new OrderItem(500, "A", 0.25m),
                    new OrderItem(500, "B", 0.12m),
                },
                MethodEnum.dummy,
                ProviderEnum.dummy,
                new DummyProviderMethodParameters(),
                new Uri("https://not.real.callback.pingpayments.com")
            );
            var response = await api.Payments.InitiatePayment(orderId, requestObject);
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
    }
}
