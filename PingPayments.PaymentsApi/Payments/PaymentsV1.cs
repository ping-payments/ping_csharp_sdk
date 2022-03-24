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
        public PaymentsV1(Lazy<InitiateEndpoint> initiateEndpoint, Lazy<GetEndpoint> getEndpoint)
        {
            _initiateEndpoint = initiateEndpoint;
            _getEndpoint = getEndpoint;
        }

        private readonly Lazy<InitiateEndpoint> _initiateEndpoint;
        private readonly Lazy<GetEndpoint> _getEndpoint;

        public async Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiateEndpoint.Value.ExecuteRequest((orderId, initiatePaymentRequest));

        public async Task<PaymentResponse> Get(Guid orderId, Guid paymentId) =>
            await _getEndpoint.Value.ExecuteRequest((orderId, paymentId));
    }
}
