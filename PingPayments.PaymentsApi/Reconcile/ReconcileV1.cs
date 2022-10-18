using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Reconcile.Request.V1;
using PingPayments.Shared;

namespace PingPayments.PaymentsApi.Reconcile
{
    public class ReconcileV1 : IReconcileV1
    {
        public ReconcileV1(Lazy<RequestReconcileOperation> requestReconcileOperation)
        {
            _requestReconcileOperation = requestReconcileOperation;
        }

        private readonly Lazy<RequestReconcileOperation> _requestReconcileOperation;

        public async Task<EmptyResponse> Request(Guid paymentOrderId, Guid paymentId, OrderItem[] orderItems) =>
            await _requestReconcileOperation.Value.ExecuteRequest((paymentOrderId, paymentId, orderItems));
    }
}
