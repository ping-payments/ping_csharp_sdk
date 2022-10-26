using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.Initiate.V1.Request
{
    public static partial class CreatePayment
    {
        public static class Autogiro
        {
            public static InitiatePaymentRequest Card
            (
                IEnumerable<OrderItem> orderItems,
                string mandateId,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.bankgirot,
                    MethodEnum.autogiro,
                    new BankgirotProviderMethodParameters(mandateId),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
