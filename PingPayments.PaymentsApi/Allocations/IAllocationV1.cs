using PingPayments.PaymentsApi.Allocations.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Allocations
{
    public interface IAllocationV1
    {
        Task<ListAllocationResponse> ListPayment(Guid paymentId);
        Task<ListAllocationResponse> ListPaymentOrder(Guid paymentOrderId);
        Task<ListAllocationResponse> ListDisbursement(Guid disbursementId);
        Task<ListAllocationResponse> ListPayout(Guid payoutId);
        Task<ListAllocationResponse> ListMerchant(Guid merchantId);
        Task<ListAllocationResponse> List((Guid? paymentId, Guid? paymentOrderId, Guid? disbursementId, Guid? payoutId, Guid? merchantId)? filter);
    }
}