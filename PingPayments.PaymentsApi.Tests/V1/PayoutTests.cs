using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PayoutTests : BaseResourceTests
    {
        [Fact]
        public async Task List_returns_200_ok_with_one_or_more_payouts()
        {
            var response = await _api.Payouts.V1.List();
            AssertHttpOK(response);
            Payout.List.V1.Payout[] payouts = response;
            Assert.True(payouts.Length >= 1);
        }
    }
}
