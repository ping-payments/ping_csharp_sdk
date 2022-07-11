using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Send.V1.Requests;
public static partial class DistributeMethod
{
    public static class SmsAndEmail
    {
        public static SendPaymentLinkRequestBody New
            (
                string phone,
                string email
            ) => new
                (
                    email,
                    phone,
                    method: new DistributeMethodEnum[] { DistributeMethodEnum.sms, DistributeMethodEnum.email }
                );
    }
}
