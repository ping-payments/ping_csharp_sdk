using PingPayments.PaymentsApi.PaymentOrders.Create.V1;
using PingPayments.PaymentsApi.PaymentOrders.Get.V1;
using PingPayments.PaymentsApi.PaymentOrders.List.V1;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.PaymentOrders
{
    public interface IPaymentOrderV1
    {
        Task<GuidResponse> Create(CreatePaymentOrderRequest createPaymentOrderRequest);
        Task<PaymentOrderResponse> Get(Guid orderId);
        Task<PaymentOrdersResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null);
        Task<EmptyResponse> Update((Guid OrderId, Guid SplitTreeId) updateRequest);
        Task<EmptyResponse> Close(Guid orderId);
        Task<EmptyResponse> Split(Guid orderId, bool fastForward = false);
        Task<EmptyResponse> Settle(Guid orderId, bool fastForward = false);
    }
}