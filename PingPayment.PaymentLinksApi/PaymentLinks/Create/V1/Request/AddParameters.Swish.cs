using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class AddParameters
    {
        public static class Swish 
        {
            public static Dictionary<string, dynamic> Ecomerce(string message) => new()
            {
                { "swish_message", message }
            };

            public static Dictionary<string, dynamic> Mcomerce(string message) => new()
            {
                { "swish_message", message }
            };

        }
    }
}
