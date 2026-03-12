using PingPayments.Shared.Enums;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class QuickPay
        {
            public static PaymentProviderMethod Vipps
                () => new
                    (
                        MethodEnum.vipps,
                        ProviderEnum.quickpay
                    );
        }
    }
}
