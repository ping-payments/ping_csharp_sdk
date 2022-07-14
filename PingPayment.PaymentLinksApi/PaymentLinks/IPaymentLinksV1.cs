using PingPayments.PaymentLinksApi.Shared;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.Shared;

namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public interface IPaymentLinksV1
    {
        Task<PaymentLinksResponse> List();
        Task<CreatePaymentLinkResponse> Create(CreatePaymentLinkRequest createPaymentLinkRequest);
        Task<PaymentLinkResponse> Get(Guid paymentLinkID);
        Task<EmptyResponse> Cancel(Guid paymentLinkID);
        Task<EmptyResponse> Send(Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody);
    }
}