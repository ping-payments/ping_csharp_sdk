using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Fortus
        {
            public static InitiatePaymentRequest Invoice
            (
                IEnumerable<OrderItem> orderItems,
                InvoiceTypeEnum invoiceType,
                string personalNumber,
                string country,
                string ip,
                string email,
                string orderNumber,
                Address? deliveryAddress = null,
                IEnumerable<InvoiceItem>? invoiceItems = null,
                string[]? additional_information = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null,
                BankId? bankId = null
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
                            Type = (int)invoiceType,
                            Country = country,
                            Ip = ip,
                            PersonalNumber = personalNumber,
                            Email = email,
                            OrderNumber = orderNumber,
                            AdditionalInformation = additional_information
                        },
                        deliveryAddress,
                        invoiceItems,
                        bankId
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
