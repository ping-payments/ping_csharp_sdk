using System;
using System.Collections.Generic;
using System.Text;

namespace PingPayments.PaymentsApi.Reconcile
{
    public class ReconcileResource : IReconcileResource
    {
        public ReconcileResource(IReconcileV1 v1) => V1 = v1;

        public IReconcileV1 V1 { get; }
    }
}
