using PingPayments.Mimic.Autogiro.Update.Mandate.V1;
using PingPayments.Mimic.Autogiro.Update.Payment.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Autogiro
{
    public class AutogiroV1 : IAutogiroV1
    {
        public AutogiroV1(Lazy<UpdateMandateOperation> updateMandateOperation,
            Lazy<UpdatePaymentOperation> updatePaymentOperation)
        {
            _updateMandateOperation = updateMandateOperation;
            _updatePaymentOperation = updatePaymentOperation;
        }
        private readonly Lazy<UpdateMandateOperation> _updateMandateOperation;
        private readonly Lazy<UpdatePaymentOperation> _updatePaymentOperation;

        public async Task<EmptyResponse> UpdateMandate(UpdateMandateRequest updateMandateRequest) =>
            await _updateMandateOperation.Value.ExecuteRequest(updateMandateRequest);
        public async Task<EmptyResponse> UpdatePayment(UpdatePaymentRequest updatePaymentRequest) =>
            await _updatePaymentOperation.Value.ExecuteRequest(updatePaymentRequest);
    }
}
