using PingPayments.PaymentsApi.Payments.Get;
using PingPayments.PaymentsApi.Payments.Initiate;
using PingPayments.PaymentsApi.Payments.Initiate.Request;
using PingPayments.PaymentsApi.Payments.Initiate.Response;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments
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
