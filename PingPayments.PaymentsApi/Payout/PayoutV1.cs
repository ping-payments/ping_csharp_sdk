using PingPayments.PaymentsApi.Payout.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payout
{
    public class PayoutV1 : IPayoutV1
    {
        private readonly Lazy<ListOperation> _listOperation;

        public PayoutV1(Lazy<ListOperation> listOperation)
        {
            _listOperation = listOperation;
        }

        public async Task<PayoutListResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null) =>
            await _listOperation.Value.ExecuteRequest(dateFilter);
    }
}
