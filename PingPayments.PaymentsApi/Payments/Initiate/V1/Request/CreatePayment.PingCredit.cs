﻿using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class PingCredit
        {
            public static InitiatePaymentRequest New
        (
            CurrencyEnum currency,
            IEnumerable<OrderItem> orderItems,
            string liquidityAccountId,
            Uri? statusCallbackUrl = null,
            IDictionary<string, dynamic>? metadata = null,
            Payer? payer = null
        ) => new
            (
                currency,
                orderItems.TotalAmountMinorCurrencyUnit(),
                orderItems,
                ProviderEnum.ping,
                MethodEnum.credit,
                new PingCreditProviderMethodParameters(liquidityAccountId),
                statusCallbackUrl,
                metadata,
                payer
            );
        }
    }
}
