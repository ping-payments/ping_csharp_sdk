using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Bankgirot
        {
            public static InitiatePaymentRequest Autogiro
            (
                IEnumerable<OrderItem> orderItems,
                string mandateId,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.bankgirot,
                    MethodEnum.autogiro,
                    new BankgirotProviderMethodParameters(mandateId),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
