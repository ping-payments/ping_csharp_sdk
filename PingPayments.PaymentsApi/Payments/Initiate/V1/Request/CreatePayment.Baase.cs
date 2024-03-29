﻿using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Baase
        {
            public static InitiatePaymentRequest BankLoan
                (

                    IEnumerable<OrderItem> orderItems,
                    Uri? statusCallbackUrl = null,
                    BaaseInvoiceInformation? invoiceInformation = null,
                    IDictionary<string, dynamic>? metadata = null,
                    Payer? payer = null
                ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.baase,
                    MethodEnum.bank_loan,
                    new BaaseProviderMethodParameters(invoiceInformation),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}