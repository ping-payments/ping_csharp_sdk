using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Dummy
        {
            public static InitiatePaymentRequest New
            (
                CurrencyEnum currency,
                int totalAmountInMinorCurrency,
                IEnumerable<OrderItem> orderItems,
                Uri statusCallbackUrl,
                PaymentStatusEnum desiredPaymentStatus = PaymentStatusEnum.COMPLETED,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    currency,
                    totalAmountInMinorCurrency,
                    orderItems,
                    ProviderEnum.dummy,
                    MethodEnum.dummy,
                    new DummyProviderMethodParameters(desiredPaymentStatus),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
