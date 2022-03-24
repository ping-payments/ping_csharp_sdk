using PingPayments.PaymentsApi.Merchants.Shared;
using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.Merchants.List
{
    public record MerchantList(Merchant[] Merchants) : EmptySuccesfulResponseBody;
}