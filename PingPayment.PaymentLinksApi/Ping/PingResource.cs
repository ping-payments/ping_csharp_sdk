using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.Ping
{
    public class PingResource : IPingResource
    {
        public PingResource(IPingV1 v1)
        {
            V1 = v1;
        }

        public IPingV1 V1 { get; }

    }
}
