

using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;

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
                        new SwishCommerceParameters(message)
                    );

            public static PaymentProviderMethod Mcommerce
                   (
                       string message
                   ) => new
                       (
                           MethodEnum.m_commerce,
                           ProviderEnum.swish,
                           new SwishCommerceParameters(message)
                       );
        }
    }
}


