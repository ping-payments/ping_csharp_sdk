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
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Shared.V1.Deposit.Invoice? invoice = null,
                string? desiredDateOfPayment = null,
                string? reference = null,
                bool? completeWhenFunded = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(ReferenceTypeEnum.OCR, invoice, reference, completeWhenFunded, desiredDateOfPayment),
                    statusCallbackUrl,
                    metadata,
                    payer
                );

            public static InitiatePaymentRequest Kid
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Shared.V1.Deposit.Invoice? invoice = null,
                string? desiredDateOfPayment = null,
                string? reference = null,
                bool? completeWhenFunded = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(ReferenceTypeEnum.KID, invoice, reference, completeWhenFunded, desiredDateOfPayment),
                    statusCallbackUrl,
                    metadata,
                    payer
                );

            public static class Invoice
            {
                public static InitiatePaymentRequest Ocr
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                DateTime desiredDateOfPayment,
                Shared.V1.Deposit.Invoice invoice,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                string? reference = null,
                bool? completeWhenFunded = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.ping,
                    MethodEnum.deposit,
                    new PingDepositParameters(
                        ReferenceTypeEnum.OCR,
                        invoice,
                        reference,
                        completeWhenFunded,
                        desiredDateOfPayment.ToString("yyyy-MM-dd")
                        ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );

                public static InitiatePaymentRequest Kid
                (
                    CurrencyEnum currency,
                    IEnumerable<OrderItem> orderItems,
                    DateTime desiredDateOfPayment,
                    Uri? statusCallbackUrl = null,
                    IDictionary<string, dynamic>? metadata = null,
                    Shared.V1.Deposit.Invoice? invoice = null,
                    string? reference = null,
                    bool? completeWhenFunded = null,
                    Payer? payer = null
                ) => new
                    (
                        currency,
                        orderItems.TotalAmountMinorCurrencyUnit(),
                        orderItems,
                        ProviderEnum.ping,
                        MethodEnum.deposit,
                        new PingDepositParameters(
                            ReferenceTypeEnum.KID,
                            invoice,
                            reference,
                            completeWhenFunded,
                            desiredDateOfPayment.ToString("yyyy-MM-dd")),
                        statusCallbackUrl,
                        metadata,
                        payer
                    );
            }
        }
    }
}
