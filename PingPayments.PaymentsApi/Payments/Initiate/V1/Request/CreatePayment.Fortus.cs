using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.Initiate.V1.Request
{
    public static partial class CreatePayment
    {
        public static class Fortus
        {
            public static InitiatePaymentRequest Invoice
            (
                IEnumerable<OrderItem> orderItems,
                int invoiceType,
                string personalNumber,
                string country,
                string ip,
                Address invoiceAddress,
                Address deliveryAddress,
                IEnumerable<InvoiceItem>? invoiceItems = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.fortus,
                    MethodEnum.invoice,
                    new FortusProviderMethodParameters
                    (
                        new Invoice
                        {
                            Type = invoiceType,
                            Country = country,
                            Ip = ip,
                            PersonalNumber = personalNumber,
                        },
                        invoiceAddress,
                        deliveryAddress,
                        invoiceItems
                    ),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
