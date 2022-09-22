using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1;
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
            Lazy<StopOperation> stopOperation
        )
        {
            _initiateOperation = initiateOperation;
            _getOperation = getOperation;
            _updateOperation = updateOperation;
            _stopOperation = stopOperation;
        }

        private readonly Lazy<InitiateOperation> _initiateOperation;
        private readonly Lazy<GetOperation> _getOperation;
        private readonly Lazy<UpdateOperation> _updateOperation;
        private readonly Lazy<StopOperation> _stopOperation;

        public async Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiateOperation.Value.ExecuteRequest((orderId, initiatePaymentRequest));

        public async Task<PaymentResponse> Get(Guid orderId, Guid paymentId) =>
            await _getOperation.Value.ExecuteRequest((orderId, paymentId));

        public async Task<EmptyResponse> Update(Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest) =>
            await _updateOperation.Value.ExecuteRequest((orderId, paymentId, UpdatePaymentRequest));

        public async Task<EmptyResponse> Stop(Guid orderId, Guid paymentId) =>
            await _stopOperation.Value.ExecuteRequest((orderId, paymentId));
    }
}
