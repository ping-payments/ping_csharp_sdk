using PingPayments.PaymentsApi.PaymentOrders.Close;
using PingPayments.PaymentsApi.PaymentOrders.Create;
using PingPayments.PaymentsApi.PaymentOrders.Get;
using PingPayments.PaymentsApi.PaymentOrders.List;
using PingPayments.PaymentsApi.PaymentOrders.Settle;
using PingPayments.PaymentsApi.PaymentOrders.Split;
using PingPayments.PaymentsApi.PaymentOrders.Update;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class PaymentOrderEndpoints
    {
        public PaymentOrderEndpoints(GetPaymentOrderEndpoint getPaymentOrderEndpoint,
                                     CreatePaymentOrderEndpoint createPaymentOrderEndpoint,
                                     UpdatePaymentOrderEndpoint updatePaymentOrderEndpoint,
                                     ListPaymentOrderEndpoint listPaymentOrderEndpoint,
                                     SplitPaymentOrderEndpoint splitPaymentOrderEndpoint, 
                                     ClosePaymentOrderEndpoint closePaymentOrderEndpoint, 
                                     SettlePaymentOrderEndpoint settlePaymentOrderEndpoint)
        {
            _getPaymentOrderEndpoint = getPaymentOrderEndpoint;
            _createPaymentOrderEndpoint = createPaymentOrderEndpoint;
            _updatePaymentOrderEndpoint = updatePaymentOrderEndpoint;
            _listPaymentOrderEndpoint = listPaymentOrderEndpoint;
            _splitPaymentOrderEndpoint = splitPaymentOrderEndpoint;
            _closePaymentOrderEndpoint = closePaymentOrderEndpoint;
            _settlePaymentOrderEndpoint = settlePaymentOrderEndpoint;
        }

        private readonly GetPaymentOrderEndpoint _getPaymentOrderEndpoint;
        private readonly CreatePaymentOrderEndpoint _createPaymentOrderEndpoint;
        private readonly UpdatePaymentOrderEndpoint _updatePaymentOrderEndpoint;
        private readonly ListPaymentOrderEndpoint _listPaymentOrderEndpoint;
        private readonly SplitPaymentOrderEndpoint _splitPaymentOrderEndpoint;
        private readonly ClosePaymentOrderEndpoint _closePaymentOrderEndpoint;
        private readonly SettlePaymentOrderEndpoint _settlePaymentOrderEndpoint;

        public async Task<PaymentOrderResponse> Get(Guid orderId) =>
            await _getPaymentOrderEndpoint.Action(orderId);
        public async Task<PaymentOrdersResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null) =>
            await _listPaymentOrderEndpoint.Action(dateFilter);
        public async Task<GuidResponse> Create(Guid? splitTreeId = null) =>
            await _createPaymentOrderEndpoint.Action(splitTreeId);
        public async Task<EmptyResponse> Update((Guid OrderId, Guid SplitTreeId) updateRequest) =>
            await _updatePaymentOrderEndpoint.Action(updateRequest);
        public async Task<EmptyResponse> Close(Guid orderId) =>
            await _closePaymentOrderEndpoint.Action(orderId);
        public async Task<EmptyResponse> Split(Guid orderId) =>
            await _splitPaymentOrderEndpoint.Action(orderId);
        public async Task<EmptyResponse> Settle(Guid orderId) =>
            await _settlePaymentOrderEndpoint.Action(orderId);
    }
}
