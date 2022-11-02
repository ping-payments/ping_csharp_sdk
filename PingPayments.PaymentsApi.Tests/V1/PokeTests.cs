using PingPayments.Tests;
using System.Threading.Tasks;


namespace PingPayments.PaymentsApi.Tests.V1
{
    public class PokeTests : PaymentsApiTestClient
    {

        [Fact]
        public async Task Request_returns_200()
        {
            var response = await _api.Poke.V1.Request(TestData.FakeCallback);
            AssertHttpOK(response);
        }
    }
}
