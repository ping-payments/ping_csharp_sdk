using PaymentsApiSdk.Shared;
using System;
using System.Net.Http;
using Xunit;

namespace PaymentsApiSdk.Tests
{
    public class BaseEndpointsTests
    {
        protected readonly PaymentsApiClient _api;
        private readonly HttpClient _httpClient;

        public BaseEndpointsTests()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(TestData.SandboxUri)
            };
            _api = new PaymentsApiClient(TestData.TenantId, _httpClient);
        }

        protected static void AssertHttpOK<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        protected static void AssertHttpNoContent<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.Equal(204, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.Null(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        protected static void AssertHttpNotFound<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.IsSuccessful);
            Assert.Null(response.Body.SuccesfulResponseBody);
            Assert.NotNull(response.Body.ErrorResponseBody);
        }

        protected static void AssertHttpUnprocessableEntity<T>(ApiResponseBase<T> response) where T : EmptySuccesfulResponseBody
        {
            Assert.NotNull(response);
            Assert.Equal(422, response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.IsSuccessful);
            Assert.Null(response.Body.SuccesfulResponseBody);
            Assert.NotNull(response.Body.ErrorResponseBody);
        }
    }
}
