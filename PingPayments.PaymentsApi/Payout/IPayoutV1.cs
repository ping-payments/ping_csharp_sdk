using PingPayments.PaymentsApi.Payout.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payout
{
    public interface IPayoutV1
    {
        Task<PayoutListResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null);
    }
}