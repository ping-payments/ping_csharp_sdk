using PingPayments.PaymentLinksApi.Files.Invoice;
using PingPayments.PaymentLinksApi.PaymentLinks;
using PingPayments.PaymentLinksApi.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi
{
    public interface IPingPaymentLinksApiClient
    {
        IPingResource Ping { get; }

        IFilesResource PaymentLinks { get;  }
    }
}
