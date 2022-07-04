using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class AddParameters
    {
        public static class Dummy
        {
            public static Dictionary<string, dynamic> New (PaymentStatusEnum desiredPaymentStatus = PaymentStatusEnum.COMPLETED) => new()
            {
                { "desired_payment_status", desiredPaymentStatus }
            };


        }


    }
}
