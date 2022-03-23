using PaymentsApiSdk.PaymentOrders.Create;
using PaymentsApiSdk.PaymentOrders.Get;
using PaymentsApiSdk.Shared;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders
{
    public class PaymentOrderEndpoints
    {
        public PaymentOrderEndpoints(GetPaymentOrderEndpoint getPaymentOrderEndpoint, CreatePaymentOrderEndpoint createPaymentOrderEndpoint)
        {
            _getPaymentOrderEndpoint = getPaymentOrderEndpoint;
            _createPaymentOrderEndpoint = createPaymentOrderEndpoint;
        }

        private readonly GetPaymentOrderEndpoint _getPaymentOrderEndpoint;
        private readonly CreatePaymentOrderEndpoint _createPaymentOrderEndpoint;

        public async Task<PaymentOrderResponse> Get(Guid orderId) =>
            await _getPaymentOrderEndpoint.Action(orderId);

        public async Task<GuidResponse> Create(Guid? splitTreeId = null) =>
            await _createPaymentOrderEndpoint.Action(splitTreeId);
    }
}
