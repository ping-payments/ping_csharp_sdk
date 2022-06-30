using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks
{
    public class PaymentLinkResource : IPaymentLinkResource
    {
        public PaymentLinkResource(IPaymentLinksV1 v1)
        {
            V1 = v1;
        }

        public IPaymentLinksV1 V1 { get; }
    }
}
