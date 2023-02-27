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
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                DateTimeOffset? DesiredDateOfPayment = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                string? reference = null,
                bool? completeWhenFunded = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(ReferenceTypeEnum.OCR, DesiredDateOfPayment, reference, completeWhenFunded),
                    statusCallbackUrl,
                    metadata
            );

            public static InitiatePaymentRequest Kid
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                DateTimeOffset? DesiredDateOfPayment = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                string? reference = null,
                bool? completeWhenFunded = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(ReferenceTypeEnum.KID, DesiredDateOfPayment, reference, completeWhenFunded),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
