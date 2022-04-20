﻿using PingPayments.PaymentsApi.Payments.Shared.V1;
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
                IEnumerable<OrderItem> orderItems,
                Uri successUrl,
                Uri cancelUrl,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
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
                IEnumerable<OrderItem> orderItems,
                Uri successUrl,
                Uri cancelUrl,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.NOK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
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