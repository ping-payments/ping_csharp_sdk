using PingPayments.PaymentsApi.Shared;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payments
{
    public interface IPingV1
    {
        Task<TextResponse> Ping();
    }
}