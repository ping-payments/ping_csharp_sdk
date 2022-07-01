using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class PaymentIq
        {
            public static PaymentProviderMethod Card
                (
                    string successUrl,
                    string errorUrl,
                    string? locale = null

                ) => new
                    (
                        MethodEnum.card,
                        ProviderEnum.payment_iq,
                        new PaymentIqParameters
                            (
                                successUrl,
                                errorUrl,
                                locale
                            )
                    );

            public static PaymentProviderMethod Vipps
                 (
                    string successUrl,
                    string errorUrl,
                    string? locale = null

                ) => new
                    (
                        MethodEnum.vipps,
                        ProviderEnum.payment_iq,
                        new PaymentIqParameters
                            (
                                successUrl,
                                errorUrl,
                                locale
                            )
                    );
        }
    }
}
