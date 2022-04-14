using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Verifone
        {
            public static InitiatePaymentRequest Card
            (
                int totalAmountInMinorCurrency,
                IEnumerable<OrderItem> orderItems,
                string firstName,
                string lastName,
                string email,
                Uri successUrl,
                Uri cancelUrl,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    totalAmountInMinorCurrency,
                    orderItems,
                    ProviderEnum.verifone,
                    MethodEnum.card,
                    new VerifoneProviderMethodParameters
                    (
                        firstName,
                        lastName,
                        email,
                        successUrl,
                        cancelUrl
                    ),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
