using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared.V1
{
    public record PaymentOrderList(PaymentOrder[]? PaymentOrders) : EmptySuccesfulResponseBody;
}