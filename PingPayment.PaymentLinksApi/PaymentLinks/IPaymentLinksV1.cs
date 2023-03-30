using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request;
using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
using PingPayments.PaymentLinksApi.Shared;

namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public interface IPaymentLinksV1
    {
        Task<PaymentLinksResponse> List();
        Task<CreatePaymentLinkResponse> Create(CreatePaymentLinkRequest createPaymentLinkRequest);
        Task<PaymentLinkResponse> Get(Guid paymentLinkID);
        Task<PaymentLinksEmptyResponse> Cancel(Guid paymentLinkID);
        Task<PaymentLinksEmptyResponse> Send(Guid paymentLinkID, SendPaymentLinkRequestBody sendPaymentLinkRequestBody);
    }
}