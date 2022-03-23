using Bogus;
using PaymentsApiSdk.Merchants.Create;
using PaymentsApiSdk.Merchants.Shared;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsApiSdk.Tests
{
    public class MerchantEndpointsTests
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
            var merchantId = Guid.Parse("04476abd-4bd4-45bb-b6ea-dcda41aded4d");
            var response = await api.Merchants.Get(merchantId);
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task Get_returns_404_for_random_guid()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var merchantId = Guid.NewGuid();
            var response = await api.Merchants.Get(merchantId);
            Assert.NotNull(response);
            Assert.Equal(404, response.StatusCode);
            Assert.True(response.IsFailure);
            Assert.False(response.IsSuccessful);
            Assert.Null(response.Body.SuccesfulResponseBody);
            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Fact]
        public async Task List_returns_200()
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);
            var response = await api.Merchants.List();
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);
            
            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Merchant[] merchants = response;
            Assert.True(merchants.Any());

            Assert.Null(response.Body.ErrorResponseBody);
        }

        [Theory]
        [InlineData("SE")]
        [InlineData("NO")]
        public async Task Create_merchant_returns_200(string country)
        {
            var tenantId = Guid.Parse("be74903f-72bd-4e21-97c4-128dcf85e2f0");
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://sandbox.pingpayments.com/payments/")
            };
            var api = new PaymentsApiClient(tenantId, httpClient);

            var fakeOrganizationGenerator = new Faker<Organization>()
                .RuleFor(x => x.Country, country)
                .RuleFor(x => x.SeOrganizationNumber, (f, o) =>
                   country == "SE" ?
                        new Randomizer().Replace("##########") :
                        null)
                .RuleFor(x => x.NoOrganizationNumber, (f, o) =>
                    country == "NO" ?
                        new Randomizer().Replace("#########") :
                        null);
            var fakeMercantGenerator = new Faker<CreateMerchantRequest>()
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Organization, fakeOrganizationGenerator.Generate());
            var fakeMerchant = fakeMercantGenerator.Generate();

            var response = await api.Merchants.Create(fakeMerchant);
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);
            Assert.False(response.IsFailure);
            Assert.True(response.IsSuccessful);

            Assert.NotNull(response.Body.SuccesfulResponseBody);
            Assert.NotEqual(Guid.Empty, (Guid)response);
            Assert.Null(response.Body.ErrorResponseBody);
        }
    }
}
