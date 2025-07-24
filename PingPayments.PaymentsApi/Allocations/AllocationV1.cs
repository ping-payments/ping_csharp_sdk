using PingPayments.PaymentsApi.Allocations.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Allocations
{
    public class AllocationV1 : IAllocationV1
    {
        public AllocationV1
        (
            Lazy<ListAllocationsOperation> listAllocationsOperation
        )
        {
            _listAllocationsOperation = listAllocationsOperation;
        }

        private readonly Lazy<ListAllocationsOperation> _listAllocationsOperation;

        public async Task<ListAllocationResponse> ListDisbursement(Guid disbursementId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((null, null, disbursementId, null, null));
        public async Task<ListAllocationResponse> ListMerchant(Guid merchantId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((null, null, null, null, merchantId));

        public async Task<ListAllocationResponse> ListPayment(Guid paymentId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((paymentId, null, null, null, null));

        public async Task<ListAllocationResponse> ListPaymentOrder(Guid paymentOrderId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((null, paymentOrderId, null, null, null));

        public async Task<ListAllocationResponse> ListPayout(Guid payoutId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((null, null, null, payoutId, null));

        public async Task<ListAllocationResponse> List((Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId)? filter) =>
            await _listAllocationsOperation.Value.ExecuteRequest(filter);
    }
}
