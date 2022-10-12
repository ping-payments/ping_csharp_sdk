using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
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
                IEnumerable<OrderItem> orderItems,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(ReferenceTypeEnum.OCR),
                    statusCallbackUrl,
                    metadata
            );

            public static InitiatePaymentRequest Kid
            (
                IEnumerable<OrderItem> orderItems,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.NOK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(ReferenceTypeEnum.KID),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
