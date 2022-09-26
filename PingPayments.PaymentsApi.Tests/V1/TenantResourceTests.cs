using System.Threading.Tasks;
using Xunit;

namespace PingPayments.PaymentsApi.Tests.V1
{

    public class TenantResourceTests : BaseResourceTests
    {
        [Fact]
        public async Task Get_returns_200()
        {
            var response = await _api.Tenants.V1.Get();
            AssertHttpOK(response);
        }

    }
}
