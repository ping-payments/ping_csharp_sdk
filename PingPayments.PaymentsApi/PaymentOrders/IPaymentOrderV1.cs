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
        Task<PaymentOrdersResponse> List((DateTimeOffset from, DateTimeOffset to) dateFilter);
        Task<PaymentOrdersResponse> List((DateTimeOffset from, DateTimeOffset to, PaymentOrderStatusEnum status) filter);
        Task<PaymentOrdersResponse> List((DateTimeOffset? from, DateTimeOffset? to, PaymentOrderStatusEnum? status, int? limit)? filter = null);
        Task<EmptyResponse> Update(Guid OrderId, UpdatePaymentOrderRequest updatePaymentOrderRequest);
        Task<EmptyResponse> Close(Guid orderId);
        Task<EmptyResponse> Split(Guid orderId, bool fastForward = false);
        Task<EmptyResponse> Settle(Guid orderId, bool fastForward = false);
        [Obsolete("Use Get Allocations(Guid orderId) instead.", true)]
        Task<AllocationsResponse> Allocations(Guid orderId);
    }
}