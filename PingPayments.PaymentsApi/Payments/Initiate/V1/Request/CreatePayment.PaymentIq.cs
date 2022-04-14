using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class PaymentIq
        {
            public static InitiatePaymentRequest Card
            (
                CurrencyEnum currency,
                int totalAmountInMinorCurrency,
                IEnumerable<OrderItem> orderItems,
                Uri successUrl,
                Uri cancelUrl,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    currency,
                    totalAmountInMinorCurrency,
                    orderItems,
                    ProviderEnum.payment_iq,
                    MethodEnum.card,
                    new PaymentIqProviderMethodParameters
                    (
                        successUrl,
                        cancelUrl
                    ),
                    statusCallbackUrl,
                    metadata
                );

            public static InitiatePaymentRequest Vipps
            (
                int totalAmountInMinorCurrency,
                IEnumerable<OrderItem> orderItems,
                Uri successUrl,
                Uri cancelUrl,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.NOK,
                    totalAmountInMinorCurrency,
                    orderItems,
                    ProviderEnum.payment_iq,
                    MethodEnum.vipps,
                    new PaymentIqProviderMethodParameters
                    (
                        successUrl,
                        cancelUrl
                    ),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
