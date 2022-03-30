using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public static class OrderItemExtensions
    {
        public static IEnumerable<OrderItem> ToOrderList(this OrderItem orderItem) => new[] { orderItem };
    }
}
