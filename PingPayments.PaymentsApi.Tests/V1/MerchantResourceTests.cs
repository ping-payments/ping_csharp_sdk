using Bogus;
using PingPayments.PaymentsApi.Merchants.Create.V1;
using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.Shared;
using PingPayments.Tests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{

    public class MerchantResourceTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.Merchants.V1.Get(TestData.MerchantId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_returns_404_for_random_guid()
        {
            var response = await _api.Merchants.V1.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task List_Data_returns_200()
        {
            var response = await _api.Merchants.V1.ListData();
            AssertHttpOK(response);
            Merchant[]? merchants = response;
            Assert.True(merchants != null && merchants.Any());
        }

        [Fact]
        public async Task List_Page_returns_200()
        {
            var response = await _api.Merchants.V1.ListPage();
            AssertHttpOK(response);
            Merchant[]? merchants = response;
            Assert.True(merchants != null && merchants.Any());
        }

        [Fact]
        public async Task List_Page_returns_200_has_links()
        {
            var response = await _api.Merchants.V1.ListPage();
            AssertHttpOK(response);
            PaginationLinks paginationLinks = response;
            Assert.NotNull(paginationLinks);
        }

        [Fact]
        public async Task Create_merchant_dk_organization_returns_200()
        {

            var createMerchantRequest = new CreateMerchantRequest
            {
                Name = "Danske Bolag",
                Organization = new Organization
                {
                    Country = "DK",
                    DkOrganizationNumber = "12345678"
                }
            };
            var response = await _api.Merchants.V1.Create(createMerchantRequest);
            AssertHttpOK(response);
            Assert.NotEqual(Guid.Empty, response);
        }

        [Theory]
        [InlineData("SE")]
        [InlineData("NO")]
        public async Task Create_merchant_organization_returns_200(string country)
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
                        null)
                .RuleFor(x => x.DkOrganizationNumber, (f, o) =>
                    country == "DK" ?
                        new Randomizer().Replace("#########") :
                        null);
            var fakeMercantGenerator = new Faker<CreateMerchantRequest>()
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Organization, fakeOrganizationGenerator.Generate());
            var fakeMerchant = fakeMercantGenerator.Generate();

            var response = await _api.Merchants.V1.Create(fakeMerchant);
            AssertHttpOK(response);
            Assert.NotEqual(Guid.Empty, response);
        }

        [Theory]
        [InlineData("SE")]
        [InlineData("DE")]
        public async Task Create_merchant_person_returns_200(string country)
        {
            var fakePersonGenerator = new Faker<Merchants.Shared.V1.Person>()
                .RuleFor(x => x.Country, country)
                .RuleFor(x => x.SePersonalIdentityNumber, (f, p) =>
                   country == "SE" ? new Randomizer().Replace("############") : null);

            var fakeMercantGenerator = new Faker<CreateMerchantRequest>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Person, fakePersonGenerator.Generate());
            var fakeMerchant = fakeMercantGenerator.Generate();

            var response = await _api.Merchants.V1.Create(fakeMerchant);
            AssertHttpOK(response);
            Assert.NotEqual(Guid.Empty, response);
        }
    }
}
