using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1;
using PingPayments.PaymentsApi.Payments.Reconcile.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.Stop.V1;
using PingPayments.PaymentsApi.Payments.Update.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments
{
    public class PaymentsV1 : IPaymentsV1
    {
        public PaymentsV1
        (
            Lazy<InitiateOperation> initiateOperation,
            Lazy<GetOperation> getOperation,
            Lazy<UpdateOperation> updateOperation,
            Lazy<ReconcileOperation> reconcileOperation,
            Lazy<StopOperation> stopOperation
        )
        {
            _initiateOperation = initiateOperation;
            _getOperation = getOperation;
            _updateOperation = updateOperation;
            _reconcileOperation = reconcileOperation;
            _stopOperation = stopOperation;
        }

        private readonly Lazy<InitiateOperation> _initiateOperation;
        private readonly Lazy<GetOperation> _getOperation;
        private readonly Lazy<UpdateOperation> _updateOperation;
        private readonly Lazy<StopOperation> _stopOperation;
        private readonly Lazy<ReconcileOperation> _reconcileOperation;

        public async Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiateOperation.Value.ExecuteRequest((orderId, initiatePaymentRequest));

        public async Task<PaymentResponse> Get(Guid orderId, Guid paymentId) =>
            await _getOperation.Value.ExecuteRequest((orderId, paymentId));

        public async Task<EmptyResponse> Update(Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest) =>
            await _updateOperation.Value.ExecuteRequest((orderId, paymentId, UpdatePaymentRequest));
        public async Task<EmptyResponse> Reconcile(Guid paymentOrderId, Guid paymentId, OrderItem[]? orderItems = null) =>
            await _reconcileOperation.Value.ExecuteRequest((paymentOrderId, paymentId, orderItems));

        public async Task<EmptyResponse> Stop(Guid orderId, Guid paymentId) =>
            await _stopOperation.Value.ExecuteRequest((orderId, paymentId));
    }
}
