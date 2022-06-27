using PingPayments.PaymentLinksApi.PaymentLinks.List.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public interface IPaymentLinksV1
    {
        Task<PaymentLinksResponse> List();
    }
}