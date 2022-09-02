using PingPayments.PaymentsApi.Payouts.Get.V1;
using PingPayments.PaymentsApi.Payouts.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payouts
{
    public interface IPayoutV1
    {
        Task<PayoutGetResponse> Get(Guid PayoutId);
        Task<PayoutListResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null);
    }
}