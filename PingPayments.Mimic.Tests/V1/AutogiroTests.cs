using PingPayments.Mimic.Autogiro.Update.Mandate.V1;
using PingPayments.Mimic.Autogiro.Update.Payment.V1;

namespace PingPayments.Mimic.Tests.V1
{
    public class AutogiroTests : MimicApiTestClient
    {

        [Fact]
        public async Task Update_mandate_status_returns_204()
        {
            var request = new UpdateMandateRequest(Guid.NewGuid(), MandateStatusEnum.APPROVED);
            var response = await _api.Autogiro.V1.UpdateMandate(request);
            AssertHttpNoContent(response);
        }

        [Fact]
        public async Task Update_payment_status_returns_204()
        {
            var request = new UpdatePaymentRequest(Guid.NewGuid(), PaymentStatusEnum.PAID);
            var response = await _api.Autogiro.V1.UpdatePayment(request);
            AssertHttpNoContent(response);
        }
    }
}
