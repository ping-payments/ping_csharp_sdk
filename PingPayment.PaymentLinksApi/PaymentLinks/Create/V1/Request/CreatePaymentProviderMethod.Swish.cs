using PingPayments.Shared.Enums;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class Swish
        {
            public static PaymentProviderMethod Ecommerce
                (
                    string message
                ) => new
                    (
                        MethodEnum.e_commerce,
                        ProviderEnum.swish,
                        PaymentProviderParameters.Swish.Ecomerce(message)
                    );

            public static PaymentProviderMethod Mcommerce
                   (
                        string message
                   ) => new
                       (
                           MethodEnum.m_commerce,
                           ProviderEnum.swish,
                           PaymentProviderParameters.Swish.Mcomerce(message)
                       );
        }
    }
}

