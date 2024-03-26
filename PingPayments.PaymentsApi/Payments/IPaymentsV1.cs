using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.Refund.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.Update.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments
{
    public interface IPaymentsV1
    {
        Task<PaymentResponse> Get(Guid orderId, Guid paymentId);
        Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest);
        Task<EmptyResponse> Update(Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest);
        Task<EmptyResponse> Reconcile(Guid paymentOrderId, Guid paymentId, OrderItem[]? orderItems = null);
        Task<RefundResponse> Refund(Guid paymentOrderId, Guid paymentId, RefundRequest refundRequest);
        Task<EmptyResponse> Stop(Guid orderId, Guid paymentId);
    }
}