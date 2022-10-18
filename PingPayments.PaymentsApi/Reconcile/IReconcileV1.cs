using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Reconcile
{
    public interface IReconcileV1
    {
        Task<EmptyResponse> Request(Guid paymentOrderId, Guid paymentId, OrderItem[] orderItems);
    }
}