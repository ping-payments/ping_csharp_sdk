using PingPayments.PaymentLinksApi.PaymentLinks.Shared.V1;
using System;
using System.Collections.Generic;


namespace PingPayments.PaymentLinksApi.PaymentLinks.Create.V1.Request
{
    public static partial class CreatePaymentProviderMethod
    {
        public static class Dummy
        {
            public static PaymentProviderMethod New
            (
               PaymentStatusEnum desiredPaymentStatus = PaymentStatusEnum.COMPLETED
            ) => new
                (
                    MethodEnum.dummy,
                    ProviderEnum.dummy,
                    new DummyParameters(desiredPaymentStatus)
                );
        }
    }
}
