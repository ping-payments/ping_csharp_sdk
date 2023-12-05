using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Billmate
        {
            public static InitiatePaymentRequest Invoice
            (
                IEnumerable<OrderItem> orderItems,
                string firstName,
                string lastName,
                string nattionalIdNumber,
                string email,
                string phoneNumber,
                string country,
                string ipAddress,
                string customerReference,
                bool isCompanyCustomer,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.billmate,
                    MethodEnum.invoice,
                    new BillmateProviderMethodParameters
                    (
                        firstName,
                        lastName,
                        nattionalIdNumber,
                        email,
                        phoneNumber,
                        country,
                        ipAddress,
                        customerReference,
                        isCompanyCustomer
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
