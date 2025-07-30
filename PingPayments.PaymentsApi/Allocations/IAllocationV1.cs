using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Allocations
{
    public interface IAllocationV1
    {
        Task<ListAllocationDataResponse> ListData(Guid? paymentId = null, Guid? paymentOrderId = null, Guid? disbursementId = null, Guid? payoutId = null, Guid? merchantId = null);
        Task<ListAllocationPageResponse> ListPage(Guid? paymentId = null, Guid? paymentOrderId = null, Guid? disbursementId = null, Guid? payoutId = null, Guid? merchantId = null, int? limit = null);
        Task<ListAllocationPageResponse> ListPage(PaginationLinkHref href);
    }
}