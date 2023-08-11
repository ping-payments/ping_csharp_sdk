using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using PingPayments.Shared;

namespace PingPayments.PaymentLinksApi.PaymentLinks.List.V1
{
    public record PaymentLinkList(PaymentLink[]? PaymentLinks) : EmptySuccessfulResponseBody;
}

