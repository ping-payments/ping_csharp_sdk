using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
public static partial class DistributeMethod
{
    public static class Email
    {
        public static SendPaymentLinkRequestBody New
            (
                string email,
                string? phone = null
            ) => new
                (
                    email,
                    phone,
                    method: new DistributeMethodEnum[] { DistributeMethodEnum.email }
                );
    }
}

