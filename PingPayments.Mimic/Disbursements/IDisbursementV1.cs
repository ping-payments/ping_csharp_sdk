using PingPayments.Mimic.Disbursements.Trigger.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Disbursements
{
    public interface IDisbursementV1
    {
        Task<TriggerDisbursementResponse> Trigger(Guid[] paymentOrderIdList);
    }
}