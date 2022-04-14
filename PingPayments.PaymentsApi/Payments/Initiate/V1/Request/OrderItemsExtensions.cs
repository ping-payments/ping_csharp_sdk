using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Collections.Generic;
using System.Linq;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static class OrderItemsExtensions
    {
        public static int TotalAmountMinorCurrency(this IEnumerable<OrderItem> orderItems) => orderItems.Sum(o => o.Amount);

        public static decimal TotalAmountInCurrency(this IEnumerable<OrderItem> orderItems) => orderItems.Sum(o => o.Amount).FromMinorCurrency();
    }
}
