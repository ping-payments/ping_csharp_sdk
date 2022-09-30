using System;
using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class DisbursementsTest : BaseResourceTests
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.Disbursements.V1.Get(TestData.DisbursementId);
            AssertHttpOK(response);
        }

        [Fact]
        public async Task Get_returns_404()
        {
            var response = await _api.Disbursements.V1.Get(Guid.NewGuid());
            AssertHttpNotFound(response);
        }


        [Fact]
        public async Task List_returns_200()
        {
            var response = await _api.Disbursements.V1.List();
            AssertHttpOK(response);
        }


        [Fact]
        public async Task List_with_filters_returns_200()
        {
            var from = new DateTimeOffset(2022, 01, 01, 0, 0, 0, TimeSpan.Zero);
            var to = from.AddMonths(6);

            var response = await _api.Disbursements.V1.List((from, to));
            AssertHttpOK(response);
        }
    }
}
