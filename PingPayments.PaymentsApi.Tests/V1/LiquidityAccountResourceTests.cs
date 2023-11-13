using PingPayments.PaymentsApi.LiquidityAccounts.Create.V1;
using PingPayments.PaymentsApi.LiquidityAccounts.Get.V1;
using PingPayments.PaymentsApi.LiquidityAccounts.Shared;
using PingPayments.Shared.Enums;
using PingPayments.Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Tests.V1
{

    public class LiquidityAccountResourceTests : PaymentsApiTestClient
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.LiquidityAccounts.V1.Get(Guid.Parse("d12d6099-8092-4245-a4f6-58157168cbea"));
            AssertHttpOK(response);
            GetLiquidityAccountResponseBody body = response;
            Assert.NotNull(body);
        }

        [Fact]
        public async Task Get_returns_404_for_random_guid()
        {
            var response = await _api.LiquidityAccounts.V1.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        public record CreateLiquidityAccountTestData(
           LegalEntityCountryEnum account_holder_country,
           string account_holder_identifier,
           LegalEntityTypeEnum account_holder_type,
           string account_holder_name,
           CurrencyEnum account_currency,
           bool enable_deposits,
           string account_name);

        public class CreateLiquidityAccountTestDataSet : IEnumerable<object[]>
        {

            public CreateLiquidityAccountTestDataSet()
            {

            }

            public static IEnumerable<object[]> TestData =>
                new List<object[]>
                {
                    new object[]
                    {
                        new CreateLiquidityAccountTestData
                        (
                            LegalEntityCountryEnum.SE,
                            "8202153953",
                            LegalEntityTypeEnum.person,
                            "Kalle Karlsson",
                            CurrencyEnum.SEK,
                            false,
                            "Test Case 1 - Swedish person with enabled deposit false"
                        )
                    },
                     new object[]
                    {
                        new CreateLiquidityAccountTestData
                        (
                            LegalEntityCountryEnum.SE,
                            "8202153953",
                            LegalEntityTypeEnum.person,
                            "Kalle Karlsson",
                            CurrencyEnum.SEK,
                            true,
                            "Test Case 2 - Swedish person with enabled deposit true"
                        ),
                    },
                      new object[]
                    {
                        new CreateLiquidityAccountTestData
                        (
                            LegalEntityCountryEnum.SE,
                            "5591235378",
                            LegalEntityTypeEnum.organization,
                            "Ping Payments AB",
                            CurrencyEnum.SEK,
                            false,
                            "Test Case 3 - Company with deposit false"
                        )
                    },
                       new object[]
                    {
                        new CreateLiquidityAccountTestData
                        (
                            LegalEntityCountryEnum.SE,
                            "5591235378",
                            LegalEntityTypeEnum.organization,
                            "Ping Payments AB",
                            CurrencyEnum.SEK,
                            true,
                            "Test Case 4 - Company with deposit true"
                        )
                    }
                };

            public IEnumerator<object[]> GetEnumerator() => TestData.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => TestData.GetEnumerator();
        }


        [Theory]
        [ClassData(typeof(CreateLiquidityAccountTestDataSet))]
        public async Task Create_LiquidityAccount_returns_200(CreateLiquidityAccountTestData x)
        {
            var payload = new CreateLiquidityAccountRequest(
                x.account_name, 
                x.account_currency, 
                x.enable_deposits, 
                new(
                    x.account_holder_name, 
                    new(
                        x.account_holder_country, 
                        x.account_holder_identifier, 
                        x.account_holder_type)));
            var response = await _api.LiquidityAccounts.V1.Create(payload);
            AssertHttpOK(response);
            CreateLiquidityAccountResponseBody body = response;
            Assert.NotEqual(Guid.Empty, body.Id);

            if (x.enable_deposits)
            {
                Assert.NotNull(body.DepositInformation);
                Assert.NotNull(body.DepositInformation.Reference);
                Assert.NotEmpty(body.DepositInformation.Reference);
                Assert.NotNull(body.DepositInformation.BankAccount);
            } 
            else
            {
                Assert.Null(body.DepositInformation);
            }
        }
    }
}
