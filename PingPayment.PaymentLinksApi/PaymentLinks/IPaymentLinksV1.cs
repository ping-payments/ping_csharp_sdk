using PingPayments.PaymentLinksApi.PaymentLinks.Get.V1;
using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public interface IPaymentLinksV1
    {
        Task<PaymentLinkResponse> Get(Guid paymentLinkID);
        Task<PaymentLinksResponse> List();
    }
}