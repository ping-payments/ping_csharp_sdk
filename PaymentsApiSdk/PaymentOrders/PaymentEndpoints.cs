using PaymentsApiSdk.PaymentOrders.Get;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders
{
    public class PaymentOrderEndpoints
    {
        public PaymentOrderEndpoints(GetPaymentOrderEndpoint getPaymentOrderEndpoint)
        {
            _getPaymentOrderEndpoint = getPaymentOrderEndpoint;
        }

        private readonly GetPaymentOrderEndpoint _getPaymentOrderEndpoint;

        public async Task<PaymentOrderResponse> Get(Guid orderId) =>
            await _getPaymentOrderEndpoint.Action(orderId);
    }
}
