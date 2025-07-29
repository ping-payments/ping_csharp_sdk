using PingPayments.PaymentsApi.Allocations.List.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Allocations
{
    public interface IAllocationV1
    {
        //Task<ListAllocationDataResponse> ListPayment(Guid paymentId);
        //Task<ListAllocationDataResponse> ListPaymentOrder(Guid paymentOrderId);
        //Task<ListAllocationDataResponse> ListDisbursement(Guid disbursementId);
        //Task<ListAllocationDataResponse> ListPayout(Guid payoutId);
        //Task<ListAllocationDataResponse> ListMerchant(Guid merchantId);
        Task<ListAllocationDataResponse> ListData(Guid? paymentId = null, Guid? paymentOrderId = null, Guid? disbursementId = null, Guid? payoutId = null, Guid? merchantId = null);
        Task<ListAllocationPageResponse> ListPage(PaginationLinkHref? href = null, Guid? paymentId = null, Guid? paymentOrderId = null, Guid? disbursementId = null, Guid? payoutId = null, Guid? merchantId = null, int? limit = null);
        Task<ListAllocationPageResponse> ListPage(PaginationLinkHref href);
        Task<ListAllocationPageResponse> ListPage();
    }
}