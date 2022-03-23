using PaymentsApiSdk.Merchants.Shared;
using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.Merchants.List
{
    public record MerchantList(Merchant[] Merchants) : EmptySuccesfulResponseBody;
}