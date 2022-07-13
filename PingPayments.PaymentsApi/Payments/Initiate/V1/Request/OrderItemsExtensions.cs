using PingPayments.Shared.Helpers;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using System.Collections.Generic;
using System.Linq;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static class OrderItemsExtensions
    {
        public static int TotalAmountMinorCurrencyUnit(this IEnumerable<OrderItem> orderItems) => orderItems.Sum(o => o.Amount);

        public static decimal TotalAmountInCurrencyUnit(this IEnumerable<OrderItem> orderItems) => orderItems.Sum(o => o.Amount).FromMinorCurrencyUnit();
    }
}
