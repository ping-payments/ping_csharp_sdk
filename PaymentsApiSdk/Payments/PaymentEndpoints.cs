using PaymentsApiSdk.Payments.Get;
using PaymentsApiSdk.Payments.Initiate;
using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Initiate.Response;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.Payments
{
    public class PaymentEndpoints
    {
        public PaymentEndpoints(InitiateEndpoint initiateEndpoint, GetEndpoint getEndpoint)
        {
            _initiateEndpoint = initiateEndpoint;
            _getEndpoint = getEndpoint;
        }

        private readonly InitiateEndpoint _initiateEndpoint;
        private readonly GetEndpoint _getEndpoint;

        public async Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiateEndpoint.Action((orderId, initiatePaymentRequest));

        public async Task<PaymentResponse> Get(Guid orderId, Guid paymentId) =>
            await _getEndpoint.Action((orderId, paymentId));
    }
}
