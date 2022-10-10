using PingPayments.Mimic.Disbursements.Trigger.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Disbursements
{
    public class DisbursementV1 : IDisbursementV1
    {
        private readonly Lazy<TriggerDisbursementOperation> _triggerDisbursementOperation;

        public DisbursementV1(Lazy<TriggerDisbursementOperation> triggerDisbursementOperation)
        {
            _triggerDisbursementOperation = triggerDisbursementOperation;
        }

        public async Task<TriggerDisbursementResponse> Trigger(Guid[] paymentOrderIdList) =>
            await _triggerDisbursementOperation.Value.ExecuteRequest(paymentOrderIdList);
    }
}
