using PingPayments.PaymentLinksApi.Shared;

namespace PingPayments.PaymentLinksApi.Tests
{
    public class PaymentLinksBaseResourceTests
    {
        protected static void AssertHttpOK<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.NotNull(response.RawBody);
            Assert.Equal(200, (int)response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.NotNull(response?.Body?.SuccessfulResponseBody);
            Assert.Null(response?.Body?.ErrorResponseBody);
        }

        protected static void AssertHttpCreated<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.NotNull(response.RawBody);
            Assert.Equal(201, (int)response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body);
            Assert.NotNull(response?.Body?.SuccessfulResponseBody);
            Assert.Null(response?.Body?.ErrorResponseBody);
        }

        protected static void AssertBadRequest<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.Equal(400, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccessfulResponseBody);
        }

        protected static void AssertHttpNoContent<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.True(string.IsNullOrWhiteSpace(response.RawBody));
            Assert.Equal(204, (int)response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response?.Body.SuccessfulResponseBody);
            Assert.Null(response?.Body?.ErrorResponseBody);
        }

        protected static void AssertHttpNotFound<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.Equal(404, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccessfulResponseBody);
        }

        protected static void AssertHttpApiError<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.Equal(403, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccessfulResponseBody);
        }

        protected static void AssertHttpUnprocessableEntity<T>(PaymentLinksApiResponseBase<T> response) where T : class
        {
            Assert.NotNull(response);
            Assert.NotNull(response.RawBody);
            Assert.Equal(422, (int)response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.ParsingError);
            Assert.False(response.IsSuccessful);
            Assert.Null(response?.Body?.SuccessfulResponseBody);
            Assert.NotNull(response?.Body?.ErrorResponseBody);
        }
    }
}
