using PingPayments.PaymentsApi.Shared;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared
{
    public record PaymentOrderList(PaymentOrder[] PaymentOrders) : EmptySuccesfulResponseBody;
}