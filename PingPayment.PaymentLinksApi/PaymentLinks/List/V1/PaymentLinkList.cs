using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public record PaymentLinkList(PaymentLink[]? PaymentLinks) : EmptySuccessfulResponseBody;
}

