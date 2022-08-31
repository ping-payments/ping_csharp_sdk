using PingPayments.Shared;

namespace PingPayments.PaymentLinksApi.Ping
{
    public interface IPingV1
    {
        Task<TextResponse> Ping();
    }
}