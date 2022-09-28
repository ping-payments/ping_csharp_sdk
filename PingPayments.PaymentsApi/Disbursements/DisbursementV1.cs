using PingPayments.PaymentsApi.Disbursements.Get.V1;
using PingPayments.PaymentsApi.Disbursements.List.V1;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Disbursements
{
    public class DisbursementV1 : IDisbursementV1
    {
        public DisbursementV1
        (
            Lazy<GetDisbursementOperation> getDisbursementOperation,
            Lazy<ListDisbursementsOperation> listDisbursementsOperation
        )
        {
            _getDisbursementOperation = getDisbursementOperation;
            _listDisbursementsOperation = listDisbursementsOperation;
        }

        private readonly Lazy<GetDisbursementOperation> _getDisbursementOperation;
        private readonly Lazy<ListDisbursementsOperation> _listDisbursementsOperation;

        public async Task<GetDisbursementResponse> Get(Guid disbursementId) =>
            await _getDisbursementOperation.Value.ExecuteRequest(disbursementId);

        public async Task<ListDisbursementResponse> List((DateTimeOffset from, DateTimeOffset to)? dateFilter) =>
            await _listDisbursementsOperation.Value.ExecuteRequest(dateFilter);
    }
}
