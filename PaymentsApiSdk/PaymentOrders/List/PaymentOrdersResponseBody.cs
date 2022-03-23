using PaymentsApiSdk.PaymentOrders.Get;
using PaymentsApiSdk.Shared;

namespace PaymentsApiSdk.PaymentOrders.List
{
    public record PaymentOrdersResponseBody(PaymentOrderResponseBody[] PaymentOrders) : EmptySuccesfulResponseBody;
}