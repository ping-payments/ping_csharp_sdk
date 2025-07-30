using PingPayments.PaymentsApi.PaymentOrders.Allocations.V1;
using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.PaymentsApi.PaymentOrders.Shared.V1;
using PingPayments.PaymentsApi.PaymentOrders.Update.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
{
    public interface IPaymentOrderV1
    {
        Task<GuidResponse> Create(CreatePaymentOrderRequest createPaymentOrderRequest);
        Task<PaymentOrderResponse> Get(Guid orderId);
        Task<PaymentOrdersDataResponse> ListData(DateTimeOffset? from = null, DateTimeOffset? to = null, PaymentOrderStatusEnum? status = null);
        Task<PaymentOrdersPageResponse> ListPage(DateTimeOffset? from = null, DateTimeOffset? to = null, PaymentOrderStatusEnum? status = null, int? limit = null);
        Task<PaymentOrdersPageResponse> ListPage(PaginationLinkHref href);
        Task<EmptyResponse> Update(Guid OrderId, UpdatePaymentOrderRequest updatePaymentOrderRequest);
        Task<EmptyResponse> Close(Guid orderId);
        Task<EmptyResponse> Split(Guid orderId, bool fastForward = false);
        Task<EmptyResponse> Settle(Guid orderId, bool fastForward = false);
        [Obsolete("Use Allocations.List(Guid orderId) instead.", true)]
        Task<AllocationsResponse> Allocations(Guid orderId);
    }
}