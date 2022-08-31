using PingPayments.PaymentsApi.Payouts.Get.V1;
using PingPayments.PaymentsApi.Payouts.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Payouts
{
    public class PayoutV1 : IPayoutV1
    {
        private readonly Lazy<ListPayoutOperation> _listOperation;

        private readonly Lazy<GetPayoutOperation> _getOperation;

        public PayoutV1(Lazy<ListPayoutOperation> listOperation, Lazy<GetPayoutOperation> getOperation)
        {
            _listOperation = listOperation;
            _getOperation = getOperation;
        }

        public async Task<PayoutGetResponse> Get(Guid PayoutId) =>
            await _getOperation.Value.ExecuteRequest(PayoutId);

        public async Task<PayoutListResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter = null) =>
            await _listOperation.Value.ExecuteRequest(dateFilter);
    }
}
