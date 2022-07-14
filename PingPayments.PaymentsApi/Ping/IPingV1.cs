using PingPayments.Shared;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Ping
{
    public interface IPingV1
    {
        Task<TextResponse> Ping();
    }
}