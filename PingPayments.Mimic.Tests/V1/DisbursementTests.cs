namespace PingPayments.Mimic.Tests.V1
{
    public class DisbursementTests : BaseResourceTests
    {

        [Fact]
        public async Task Trigger_disbursement_returns_200()
        {
            Guid[] paymentOrderIdList = new[] { new Guid() };
            var response = await _api.Disbursement.V1.Trigger(paymentOrderIdList);
            AssertHttpOK(response);
        }


        [Fact]
        public async Task Trigger_disbursement_returns_422()
        {
            Guid[] OrderIdList = Array.Empty<Guid>();
            var response = await _api.Disbursement.V1.Trigger(OrderIdList);
            AssertHttpUnprocessableEntity(response);
        }
    }
}
