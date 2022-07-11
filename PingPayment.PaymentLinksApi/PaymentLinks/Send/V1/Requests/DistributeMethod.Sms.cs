using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
public static partial class DistributeMethod
{
    public static class Sms
    {
        public static SendPaymentLinkRequestBody New
            (
                string phone,
                string? email = null
            ) => new
                (
                    email,
                    phone,
                    method: new DistributeMethodEnum[] { DistributeMethodEnum.sms }
                );
    }
}

