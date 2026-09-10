using PingPayments.Mimic.PaymentConsent.Update.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.PaymentConsent
{
    public class PaymentConsentV1 : IPaymentConsentV1
    {
        private readonly Lazy<UpdatePaymentConsentOperation> _updateOperation;

        public PaymentConsentV1(Lazy<UpdatePaymentConsentOperation> updateOperation) =>
            _updateOperation = updateOperation;

        public async Task<EmptyResponse> Update(Guid consentId, PaymentConsentStatusEnum status) =>
            await _updateOperation.Value.ExecuteRequest((consentId, status));
    }
}
