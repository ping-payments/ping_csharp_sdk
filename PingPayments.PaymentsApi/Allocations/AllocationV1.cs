using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Allocations
{
    public class AllocationV1 : IAllocationV1
    {
        public AllocationV1
        (
            Lazy<ListAllocationsDataOperation> listAllocationsOperation,
            Lazy<ListAllocationsPageOperation> listAllocationsPaginatingOperation
        )
        {
            _listAllocationsOperation = listAllocationsOperation;
            _listAllocationsPaginatingOperation = listAllocationsPaginatingOperation;
        }

        private readonly Lazy<ListAllocationsDataOperation> _listAllocationsOperation;
        private readonly Lazy<ListAllocationsPageOperation> _listAllocationsPaginatingOperation;

        public async Task<ListAllocationDataResponse> ListData(Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((paymentId, paymentOrderId, disbursementId, payoutId, merchantId));

        public async Task<ListAllocationPageResponse> ListPage(Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId, int? limit) =>
            await _listAllocationsPaginatingOperation.Value.ExecuteRequest((null, payoutId, paymentOrderId, disbursementId, payoutId, merchantId, limit));

        public async Task<ListAllocationPageResponse> ListPage(PaginationLinkHref href) =>
            await _listAllocationsPaginatingOperation.Value.ExecuteRequest((href, null, null, null, null, null, null));
    }
}
