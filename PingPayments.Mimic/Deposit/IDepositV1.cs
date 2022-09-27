using PingPayments.Mimic.Deposit.Create.V1;
using PingPayments.Shared;
using System.Threading.Tasks;

namespace PingPayments.Mimic.Deposit
{
    public interface IDepositV1
    {
        Task<EmptyResponse> Create(CreateDepositRequest createDepositRequest);
    }
}