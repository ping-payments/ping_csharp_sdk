using PingPayments.Shared.Enums;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class PaymentIq
        {
            public static PaymentProviderMethod Card
                () => new
                    (
                        MethodEnum.card,
                        ProviderEnum.payment_iq
                    );

            public static PaymentProviderMethod Vipps
                 () => new
                    (
                        MethodEnum.vipps,
                        ProviderEnum.payment_iq
                    );
        }
    }
}
