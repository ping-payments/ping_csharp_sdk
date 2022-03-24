using PingPayments.PaymentsApi.Merchants.Shared.V1;
using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.Merchants.List.V1
{
    public record MerchantList(Merchant[] Merchants) : EmptySuccesfulResponseBody;
}