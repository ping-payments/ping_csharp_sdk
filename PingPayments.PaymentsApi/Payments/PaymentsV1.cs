using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1;
using PingPayments.PaymentsApi.Payments.List.V1;
using PingPayments.PaymentsApi.Payments.Reconcile.V1;
using PingPayments.PaymentsApi.Payments.Refund.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.Stop.V1;
using PingPayments.PaymentsApi.Payments.Update.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
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
            Lazy<ListOperation> listOperation,
            Lazy<UpdateOperation> updateOperation,
            Lazy<ReconcileOperation> reconcileOperation,
            Lazy<RefundOperation> refundOperation,
            Lazy<StopOperation> stopOperation
        )
        {
            _initiateOperation = initiateOperation;
            _getOperation = getOperation;
            _listOperation = listOperation;
            _updateOperation = updateOperation;
            _reconcileOperation = reconcileOperation;
            _stopOperation = stopOperation;
            _refundOperation = refundOperation;
        }

        private readonly Lazy<InitiateOperation> _initiateOperation;
        private readonly Lazy<GetOperation> _getOperation;
        private readonly Lazy<ListOperation> _listOperation;
        private readonly Lazy<UpdateOperation> _updateOperation;
        private readonly Lazy<StopOperation> _stopOperation;
        private readonly Lazy<ReconcileOperation> _reconcileOperation;
        private readonly Lazy<RefundOperation> _refundOperation;

        public async Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiateOperation.Value.ExecuteRequest((orderId, initiatePaymentRequest));

        public async Task<PaymentResponse> Get(Guid orderId, Guid paymentId) =>
            await _getOperation.Value.ExecuteRequest((orderId, paymentId));

        public async Task<EmptyResponse> Update(Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest) =>
            await _updateOperation.Value.ExecuteRequest((orderId, paymentId, UpdatePaymentRequest));
        public async Task<EmptyResponse> Reconcile(Guid paymentOrderId, Guid paymentId, OrderItem[]? orderItems = null) =>
            await _reconcileOperation.Value.ExecuteRequest((paymentOrderId, paymentId, orderItems));

        public async Task<RefundResponse> Refund(Guid paymentOrderId, Guid paymentId, RefundRequest refundRequest) =>
            await _refundOperation.Value.ExecuteRequest((paymentOrderId, paymentId, refundRequest));

        public async Task<EmptyResponse> Stop(Guid orderId, Guid paymentId) =>
            await _stopOperation.Value.ExecuteRequest((orderId, paymentId));

        public async Task<PaymentsResponse> List(Guid paymentOrderId) =>
            await _listOperation.Value.ExecuteRequest((null, null, null, null, null, paymentOrderId, null, null));

        public async Task<PaymentsResponse> List(DateTimeOffset from, DateTimeOffset to, PaymentStatusEnum status) =>
            await _listOperation.Value.ExecuteRequest((from, to, status, null, null, null, null, null));
        public async Task<PaymentsResponse> List(DateTimeOffset from, DateTimeOffset to, MethodEnum method) =>
            await _listOperation.Value.ExecuteRequest((from, to, null, method, null, null, null, null));

        public async Task<PaymentsResponse> List(DateTimeOffset from, DateTimeOffset to, ProviderEnum provider) =>
            await _listOperation.Value.ExecuteRequest((from, to, null, null, provider, null, null, null));

        public async Task<PaymentsResponse> List(DateTimeOffset from, DateTimeOffset to, bool refundRequested) =>
            await _listOperation.Value.ExecuteRequest((from, to, null, null, null, null, refundRequested, null));

        public async Task<PaymentsResponse> List((DateTimeOffset? from, DateTimeOffset? to, PaymentStatusEnum? status, MethodEnum? method, ProviderEnum? provider, Guid? paymentOrderId, bool? refundRequested, int? limit)? filter = null) =>
            await _listOperation.Value.ExecuteRequest(filter);
    }

}
