using PingPayments.PaymentsApi.PaymentOrders.Close.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Settle.V1;
using PingPayments.PaymentsApi.PaymentOrders.Split.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.PaymentsApi.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class PaymentOrderV1 : IPaymentOrderV1
    {
        public PaymentOrderV1(Lazy<GetPaymentOrderEndpoint> getPaymentOrderEndpoint,
                              Lazy<CreatePaymentOrderEndpoint> createPaymentOrderEndpoint,
                              Lazy<UpdatePaymentOrderEndpoint> updatePaymentOrderEndpoint,
                              Lazy<ListPaymentOrderEndpoint> listPaymentOrderEndpoint,
                              Lazy<SplitPaymentOrderEndpoint> splitPaymentOrderEndpoint,
                              Lazy<ClosePaymentOrderEndpoint> closePaymentOrderEndpoint,
                              Lazy<SettlePaymentOrderEndpoint> settlePaymentOrderEndpoint)
        {
            _getPaymentOrderEndpoint = getPaymentOrderEndpoint;
            _createPaymentOrderEndpoint = createPaymentOrderEndpoint;
            _updatePaymentOrderEndpoint = updatePaymentOrderEndpoint;
            _listPaymentOrderEndpoint = listPaymentOrderEndpoint;
            _splitPaymentOrderEndpoint = splitPaymentOrderEndpoint;
            _closePaymentOrderEndpoint = closePaymentOrderEndpoint;
            _settlePaymentOrderEndpoint = settlePaymentOrderEndpoint;
        }

        private readonly Lazy<GetPaymentOrderEndpoint> _getPaymentOrderEndpoint;
        private readonly Lazy<CreatePaymentOrderEndpoint> _createPaymentOrderEndpoint;
        private readonly Lazy<UpdatePaymentOrderEndpoint> _updatePaymentOrderEndpoint;
        private readonly Lazy<ListPaymentOrderEndpoint> _listPaymentOrderEndpoint;
        private readonly Lazy<SplitPaymentOrderEndpoint> _splitPaymentOrderEndpoint;
        private readonly Lazy<ClosePaymentOrderEndpoint> _closePaymentOrderEndpoint;
        private readonly Lazy<SettlePaymentOrderEndpoint> _settlePaymentOrderEndpoint;

        public async Task<PaymentOrderResponse> Get(Guid orderId) =>
            await _getPaymentOrderEndpoint.Value.ExecuteRequest(orderId);
        public async Task<PaymentOrdersResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null) =>
            await _listPaymentOrderEndpoint.Value.ExecuteRequest(dateFilter);
        public async Task<GuidResponse> Create(Guid? splitTreeId = null) =>
            await _createPaymentOrderEndpoint.Value.ExecuteRequest(splitTreeId);
        public async Task<EmptyResponse> Update((Guid OrderId, Guid SplitTreeId) updateRequest) =>
            await _updatePaymentOrderEndpoint.Value.ExecuteRequest(updateRequest);
        public async Task<EmptyResponse> Close(Guid orderId) =>
            await _closePaymentOrderEndpoint.Value.ExecuteRequest(orderId);
        public async Task<EmptyResponse> Split(Guid orderId) =>
            await _splitPaymentOrderEndpoint.Value.ExecuteRequest(orderId);
        public async Task<EmptyResponse> Settle(Guid orderId) =>
            await _settlePaymentOrderEndpoint.Value.ExecuteRequest(orderId);
    }
}
