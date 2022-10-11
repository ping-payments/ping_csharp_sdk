using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPayments.PaymentsApi.PaymentOrders.Shared.V1
{
    public record AllocationList(Allocation[] Allocations) : EmptySuccesfulResponseBody;
}
