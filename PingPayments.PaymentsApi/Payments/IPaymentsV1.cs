using PingPayments.PaymentsApi.Payments.Get.V1;
using PingPayments.PaymentsApi.Payments.List.V1;
using PingPayments.PaymentsApi.Payments.Refund.V1;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.Update.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Response;
using PingPayments.Shared;
using PingPayments.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments
{
    public interface IPaymentsV1
    {
        Task<PaymentResponse> Get(Guid orderId, Guid paymentId);
        Task<PaymentsDataResponse> ListData(DateTimeOffset? from = null, DateTimeOffset? to = null, PaymentStatusEnum? status = null, MethodEnum? method = null, ProviderEnum? provider = null, Guid? paymentOrderId = null, bool? refundRequested = null);
        Task<PaymentsPageResponse> ListPage(DateTimeOffset? from = null, DateTimeOffset? to = null, PaymentStatusEnum? status = null, MethodEnum? method = null, ProviderEnum? provider = null, Guid? paymentOrderId = null, bool? refundRequested = null, int? limit = null);
        Task<PaymentsPageResponse> ListPage(PaginationLinkHref href);
        Task<InitiatePaymentResponse> Initiate(Guid orderId, InitiatePaymentRequest initiatePaymentRequest);
        Task<EmptyResponse> Update(Guid orderId, Guid paymentId, UpdatePaymentRequest UpdatePaymentRequest);
        Task<EmptyResponse> Reconcile(Guid paymentOrderId, Guid paymentId, OrderItem[]? orderItems = null);
        Task<RefundResponse> Refund(Guid paymentOrderId, Guid paymentId, RefundRequest refundRequest);
        Task<EmptyResponse> Stop(Guid orderId, Guid paymentId);
    }
}