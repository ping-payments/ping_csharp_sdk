using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;
using PingPayments.PaymentsApi.Payments.Shared.V1.VippsMobilepayCheckout;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class VippsMobilepay
        {
            public static InitiatePaymentRequest Checkout
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                string paymentDescription,
                Uri returnUrl,
                PrefillCustomer prefillCustomer,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.vipps_mobilepay,
                    MethodEnum.checkout,
                    new VippsMobilepayCheckoutParameters
                    (
                        paymentDescription,
                        returnUrl,
                        prefillCustomer
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
