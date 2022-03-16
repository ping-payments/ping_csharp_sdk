using PaymentsApiSdk.Payments.InitiatePayment.Request;
using PaymentsApiSdk.Payments.InitiatePayment.Response;
using System;
using System.Collections.Generic;
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
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments")
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
                MethodEnum.mobile,
                ProviderEnum.swish,
                new SwishProviderMethodParameters("Testbetalning", "0703879474"),
                new Uri("https://not.real.callback.pingpayments.com")
            );
            var response = await api.Payments.InitiatePayment(orderId, requestObject);
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.Null(response.Body?.ErrorResponseBody);
            InitiatePaymentResponseBody body = response.Body.SuccesfulResponseBody;
            Assert.NotNull(body);
            
            Assert.True(body?.Id != Guid.Empty);

            Assert.Null(body.Billmate);
            Assert.Null(body.Verifone);

            Assert.NotNull(body.Swish);
            Assert.NotNull(body.Swish.SwishUrl);
            Assert.NotEmpty(body.Swish.SwishUrl);            
        }
    }
}
