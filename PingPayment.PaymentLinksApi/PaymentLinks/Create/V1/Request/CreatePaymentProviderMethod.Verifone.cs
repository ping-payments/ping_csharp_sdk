using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class Verifone
        {
            public static PaymentProviderMethod Card() => new
                (
                    MethodEnum.card,
                    ProviderEnum.verifone
                );
        }
    }
}