using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.Payout.List.V1
{
    public record PayoutListResponseBody(Payout[] Payouts) : EmptySuccesfulResponseBody;
}
