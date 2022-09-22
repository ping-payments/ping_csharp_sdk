using PingPayments.PaymentsApi.Payments.Get.V1;
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
        Task<EmptyResponse> Stop(Guid orderId, Guid paymentId);
    }
}