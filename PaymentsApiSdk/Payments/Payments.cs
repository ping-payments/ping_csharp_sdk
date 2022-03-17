using PaymentsApiSdk.Payments.Initiate.Request;
using PaymentsApiSdk.Payments.Initiate.Response;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.Payments
{
    public class Payments
    {
        public Payments(Initiate.Initiate initiate)
        {
            _initiate = initiate;
        }
        private readonly Initiate.Initiate _initiate;

        public async Task<InitiatePaymentResponse> InitiatePayment(Guid orderId, InitiatePaymentRequest initiatePaymentRequest) =>
            await _initiate.InitiatePayment(orderId, initiatePaymentRequest);
    }
}
