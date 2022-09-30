using PingPayments.Shared.Enums;

namespace PingPayments.Mimic.Tests.V1
{
    public class MerchantTests : BaseResourceTests
    {
        [Fact]
        public async Task Update_merchant_status_returns_204()
        {
            var response = await _api.Merchant.V1.Update(TestData.MerchantId, MerchantStatus.APPROVED);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Update_merchant_status_returns_422()
        {
            var response = await _api.Merchant.V1.Update(Guid.NewGuid(), MerchantStatus.APPROVED);
            AssertHttpUnprocessableEntity(response);
        }
    }
}
