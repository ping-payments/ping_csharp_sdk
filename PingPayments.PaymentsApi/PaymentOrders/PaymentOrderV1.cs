using PingPayments.PaymentsApi.PaymentOrders.Allocations.V1;
using PingPayments.PaymentsApi.PaymentOrders.Close.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Settle.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.PaymentOrders.Split.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
{
    public class PaymentOrderV1 : IPaymentOrderV1
    {
        public PaymentOrderV1(Lazy<GetPaymentOrderOperation> getPaymentOrderOperation,
                              Lazy<CreatePaymentOrderOperation> createPaymentOrderOperation,
                              Lazy<UpdatePaymentOrderOperation> updatePaymentOrderOperation,
                              Lazy<ListPaymentOrderDataOperation> listPaymentOrderDataOperation,
                              Lazy<ListPaymentOrderPageOperation> listPaymentOrderPageOperation,
                              Lazy<SplitPaymentOrderOperation> splitPaymentOrderOperation,
                              Lazy<ClosePaymentOrderOperation> closePaymentOrderOperation,
                              Lazy<SettlePaymentOrderOperation> settlePaymentOrderOperation,
                              Lazy<GetPaymentOrderAllocationsOperation> getPaymentOrderAllocationsOperation)
        {
            _getPaymentOrderOperation = getPaymentOrderOperation;
            _createPaymentOrderOperation = createPaymentOrderOperation;
            _updatePaymentOrderOperation = updatePaymentOrderOperation;
            _listPaymentOrderDataOperation = listPaymentOrderDataOperation;
            _listPaymentOrderPageOperation = listPaymentOrderPageOperation;
            _splitPaymentOrderOperation = splitPaymentOrderOperation;
            _closePaymentOrderOperation = closePaymentOrderOperation;
            _settlePaymentOrderOperation = settlePaymentOrderOperation;
            _getPaymentOrderAllocationsOperation = getPaymentOrderAllocationsOperation;
        }

        private readonly Lazy<GetPaymentOrderOperation> _getPaymentOrderOperation;
        private readonly Lazy<CreatePaymentOrderOperation> _createPaymentOrderOperation;
        private readonly Lazy<UpdatePaymentOrderOperation> _updatePaymentOrderOperation;
        private readonly Lazy<ListPaymentOrderDataOperation> _listPaymentOrderDataOperation;
        private readonly Lazy<ListPaymentOrderPageOperation> _listPaymentOrderPageOperation;
        private readonly Lazy<SplitPaymentOrderOperation> _splitPaymentOrderOperation;
        private readonly Lazy<ClosePaymentOrderOperation> _closePaymentOrderOperation;
        private readonly Lazy<SettlePaymentOrderOperation> _settlePaymentOrderOperation;
        private readonly Lazy<GetPaymentOrderAllocationsOperation> _getPaymentOrderAllocationsOperation;

        public async Task<PaymentOrderResponse> Get(Guid orderId) =>
            await _getPaymentOrderOperation.Value.ExecuteRequest(orderId);
        //public async Task<PaymentOrdersDataResponse> ListData((DateTimeOffset from, DateTimeOffset to) dateFilter) =>
        //    await _listPaymentOrderOperation.Value.ExecuteRequest((dateFilter.from, dateFilter.to, null));
        public async Task<PaymentOrdersDataResponse> ListData(DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status) =>
            await _listPaymentOrderDataOperation.Value.ExecuteRequest((from, to, status));
        public async Task<PaymentOrdersPageResponse> ListPage(DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit) =>
            await _listPaymentOrderPageOperation.Value.ExecuteRequest((null, from, to, status, limit));
        public async Task<PaymentOrdersPageResponse> ListPage(PaginationLinkHref href) =>
            await _listPaymentOrderPageOperation.Value.ExecuteRequest((href, null, null,null, null));
        public async Task<GuidResponse> Create(CreatePaymentOrderRequest createPaymentOrderRequest) =>
            await _createPaymentOrderOperation.Value.ExecuteRequest(createPaymentOrderRequest);
        public async Task<EmptyResponse> Update(Guid orderId, UpdatePaymentOrderRequest updatePaymentOrderRequest) =>
            await _updatePaymentOrderOperation.Value.ExecuteRequest((orderId, updatePaymentOrderRequest));
        public async Task<EmptyResponse> Close(Guid orderId) =>
            await _closePaymentOrderOperation.Value.ExecuteRequest(orderId);
        public async Task<EmptyResponse> Split(Guid orderId, bool fastForward = false) =>
            await _splitPaymentOrderOperation.Value.ExecuteRequest((orderId, fastForward));
        public async Task<EmptyResponse> Settle(Guid orderId, bool fastForward = false) =>
            await _settlePaymentOrderOperation.Value.ExecuteRequest((orderId, fastForward));
        public async Task<AllocationsResponse> Allocations(Guid orderId) =>
            await _getPaymentOrderAllocationsOperation.Value.ExecuteRequest(orderId);
    }
}
