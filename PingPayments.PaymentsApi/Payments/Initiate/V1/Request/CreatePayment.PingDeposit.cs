using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class PingDeposit
        {
            public static InitiatePaymentRequest Ocr
        (
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            PingDepositReferenceTypesEnum referenceType,
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.SEK,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.ping,
                MethodEnum.deposit,
                new PingDepositParameters(referenceType),
                statusCallbackUrl,
                metadata
            );

            public static InitiatePaymentRequest Kid
            (
                int totalAmountInMinorCurrency,
                IEnumerable<OrderItem> orderItems,
                PingDepositReferenceTypesEnum referenceType,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.NOK,
                    totalAmountInMinorCurrency,
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(referenceType),
                    statusCallbackUrl,
                    metadata
                );
        }       
    }
}
