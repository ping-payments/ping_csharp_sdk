using PingPayments.PaymentsApi.Payouts.Shared;
using PingPayments.Tests;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PayoutTests : PaymentsApiTestClient
    {

        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.Payouts.V1.Get(TestData.PayoutId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_404_on_non_existing_payout()
        {
            var response = await _api.Payouts.V1.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }

        [Fact]
        public async Task List_returns_200_ok_with_one_or_more_payouts()
        {
            var response = await _api.Payouts.V1.List();
            AssertHttpOK(response);
            PayoutResponseBody[] payouts = response;
            Assert.True(payouts.Length >= 1);
        }

        [Fact]
        public async Task List_returns_200_with_filter()
        {
            var from = new DateTimeOffset(2022, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddMonths(12);
            var response = await _api.Payouts.V1.List((from, to));
            AssertHttpOK(response);
            PayoutResponseBody[] payouts = response;
            Assert.True(payouts.Any());
        }
    }
}
