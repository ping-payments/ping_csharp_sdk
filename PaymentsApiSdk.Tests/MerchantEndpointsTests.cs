using Bogus;
using PaymentsApiSdk.Merchants.Create;
using PaymentsApiSdk.Merchants.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PaymentsApiSdk.Tests
{

    public class MerchantEndpointsTests : BaseEndpointsTests
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.Merchants.Get(TestData.MerchantId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_returns_404_for_random_guid()
        {
            var response = await _api.Merchants.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task List_returns_200()
        {
            var response = await _api.Merchants.List(); 
            AssertHttpOK(response);
            Merchant[] merchants = response;
            Assert.True(merchants != null && merchants.Any());
        }

        [Theory]
        [InlineData("SE")]
        [InlineData("NO")]
        public async Task Create_merchant_returns_200(string country)
        {
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

            var response = await _api.Merchants.Create(fakeMerchant);
            AssertHttpOK(response);
            Assert.NotEqual(Guid.Empty, response);
        }
    }
}
