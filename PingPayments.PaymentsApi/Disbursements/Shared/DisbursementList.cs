using PingPayments.Shared;

namespace PingPayments.PaymentsApi.Disbursements.Shared
{
    public record DisbursementList(Disbursement[] Disbursements) : EmptySuccesfulResponseBody;
}
