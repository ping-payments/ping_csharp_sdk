using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.PaymentOrders.Shared
{
    public record PaymentOrderList(PaymentOrder[] PaymentOrders) : EmptySuccesfulResponseBody;
}