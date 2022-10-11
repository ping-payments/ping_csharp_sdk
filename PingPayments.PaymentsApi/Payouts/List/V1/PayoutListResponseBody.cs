using PingPayments.PaymentsApi.Payouts.Shared;
using PingPayments.Shared;

namespace PingPayments.PaymentsApi.Payouts.List.V1
{
    public record PayoutListResponseBody(PayoutResponseBody[] Payouts) : EmptySuccessfulResponseBody;
}
