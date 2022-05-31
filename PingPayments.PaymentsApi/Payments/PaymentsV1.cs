using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Initiate.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments
{
    public class PaymentsV1 : IPaymentsV1
    {
        public PaymentsV1(Lazy<InitiateOperation> initiateOperation, Lazy<GetOperation> getOperation)
        {
            _initiateOperation = initiateOperation;
            _getOperation = getOperation;
        }

        private readonly Lazy<InitiateOperation> _initiateOperation;
        private readonly Lazy<GetOperation> _getOperation;

        public async Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiateOperation.Value.ExecuteRequest((orderId, initiatePaymentRequest));

        public async Task<PaymentResponse> Get(Guid orderId, Guid paymentId) =>
            await _getOperation.Value.ExecuteRequest((orderId, paymentId));
    }
}
