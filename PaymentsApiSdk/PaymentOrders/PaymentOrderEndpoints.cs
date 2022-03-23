using PaymentsApiSdk.PaymentOrders.Create;
using PaymentsApiSdk.PaymentOrders.Get;
using PaymentsApiSdk.PaymentOrders.List;
using PaymentsApiSdk.PaymentOrders.Update;
using PaymentsApiSdk.Shared;
using System;
using System.Threading.Tasks;

namespace PaymentsApiSdk.PaymentOrders
{
    public class PaymentOrderEndpoints
    {
        public PaymentOrderEndpoints(GetPaymentOrderEndpoint getPaymentOrderEndpoint,
                                     CreatePaymentOrderEndpoint createPaymentOrderEndpoint,
                                     UpdatePaymentOrderEndpoint updatePaymentOrderEndpoint, 
                                     ListPaymentOrderEndpoint listPaymentOrderEndpoint)
        {
            _getPaymentOrderEndpoint = getPaymentOrderEndpoint;
            _createPaymentOrderEndpoint = createPaymentOrderEndpoint;
            _updatePaymentOrderEndpoint = updatePaymentOrderEndpoint;
            _listPaymentOrderEndpoint = listPaymentOrderEndpoint;
        }

        private readonly GetPaymentOrderEndpoint _getPaymentOrderEndpoint;
        private readonly CreatePaymentOrderEndpoint _createPaymentOrderEndpoint;
        private readonly UpdatePaymentOrderEndpoint _updatePaymentOrderEndpoint;
        private readonly ListPaymentOrderEndpoint _listPaymentOrderEndpoint;

        public async Task<PaymentOrderResponse> Get(Guid orderId) =>
            await _getPaymentOrderEndpoint.Action(orderId);
        public async Task<PaymentOrdersResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null) =>
            await _listPaymentOrderEndpoint.Action(dateFilter);
        public async Task<GuidResponse> Create(Guid? splitTreeId = null) =>
            await _createPaymentOrderEndpoint.Action(splitTreeId);
        public async Task<EmptyResponse> Update((Guid OrderId, Guid SplitTreeId) updateRequest) =>
            await _updatePaymentOrderEndpoint.Action(updateRequest);
    }
}
