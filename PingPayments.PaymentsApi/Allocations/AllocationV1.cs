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

        //public async Task<ListAllocationDataResponse> ListDisbursement(Guid disbursementId) =>
        //    await _listAllocationsOperation.Value.ExecuteRequest((null, null, disbursementId, null, null));
        //public async Task<ListAllocationDataResponse> ListMerchant(Guid merchantId) =>
        //    await _listAllocationsOperation.Value.ExecuteRequest((null, null, null, null, merchantId));

        //public async Task<ListAllocationDataResponse> ListPayment(Guid paymentId) =>
        //    await _listAllocationsOperation.Value.ExecuteRequest((paymentId, null, null, null, null));

        //public async Task<ListAllocationDataResponse> ListPaymentOrder(Guid paymentOrderId) =>
        //    await _listAllocationsOperation.Value.ExecuteRequest((null, paymentOrderId, null, null, null));

        //public async Task<ListAllocationDataResponse> ListPayout(Guid payoutId) =>
        //    await _listAllocationsOperation.Value.ExecuteRequest((null, null, null, payoutId, null));

        public async Task<ListAllocationDataResponse> ListData(Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId) =>
            await _listAllocationsOperation.Value.ExecuteRequest((paymentId, paymentOrderId, disbursementId, payoutId, merchantId));

        public async Task<ListAllocationPageResponse> ListPage(PaginationLinkHref? href, Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId, int? limit) =>
            await _listAllocationsPaginatingOperation.Value.ExecuteRequest((href, payoutId, paymentOrderId, disbursementId, payoutId, merchantId, limit));

        public async Task<ListAllocationPageResponse> ListPage(PaginationLinkHref href) =>
            await _listAllocationsPaginatingOperation.Value.ExecuteRequest((href, null, null, null, null, null, null));

        public async Task<ListAllocationPageResponse> ListPage() =>
            await _listAllocationsPaginatingOperation.Value.ExecuteRequest(null);
    }
}
