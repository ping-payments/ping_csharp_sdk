using PingPayments.PaymentLinksApi.Helpers;
using PingPayments.Shared;

namespace PingPayments.PaymentLinksApi.Tests.V1
{
    public class BaseResourceTests
    {
        protected readonly IPingPaymentLinksApiClient _api;
        private readonly HttpClient _httpClient;

        public BaseResourceTests()
        {
            _httpClient = new HttpClient().ConfigurePingPaymentsClient(PingEnvironments.PaymentLinksApi.SandboxUri, TestData.TenantId);
            _api = new PingPaymentLinksApiClient(_httpClient);
        }

        protected static void AssertHttpOK<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.NotNull(response.RawBody);
            Assert.Equal(200, (int)response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.NotNull(response?.Body?.SuccesfulResponseBody);
            Assert.Null(response?.Body?.ErrorResponseBody);
        }

        protected static void AssertHttpNoContent<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.True(string.IsNullOrWhiteSpace(response.RawBody));
            Assert.Equal(204, (int)response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response?.Body.SuccesfulResponseBody);
            Assert.Null(response?.Body?.ErrorResponseBody);
        }

        protected static void AssertHttpNotFound<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.Equal(404, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccesfulResponseBody);
        }

        protected static void AssertHttpUnprocessableEntity<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.NotNull(response.RawBody);
            Assert.Equal(422, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccesfulResponseBody);
            Assert.NotNull(response?.Body?.ErrorResponseBody);
        }

        protected static void AssertHttpApiError<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.Equal(403, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccesfulResponseBody);
        }
    }
}
