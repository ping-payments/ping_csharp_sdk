using PaymentsApiSdk.Payments.InitiatePayment;
using PaymentsApiSdk.Payments.InitiatePayment.Request;
using PaymentsApiSdk.Payments.InitiatePayment.Response;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.Payments
{
    public class PaymentsEndpoints
    {
        public PaymentsEndpoints(InitiatePaymentEndpoint initiatePaymentEndpoint)
        {
            _initiatePaymentEndpoint = initiatePaymentEndpoint;
        }
        private readonly InitiatePaymentEndpoint _initiatePaymentEndpoint;

        public async Task<InitiatePaymentResponse> InitiatePayment(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiatePaymentEndpoint.InitiatePayment(orderId, initiatePaymentRequest);
    }
}
