using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class PayPal
        {
            public static InitiatePaymentRequest Ppcp
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                string description,
                Guid designatedMerchantId,
                PayPalItemCategoryEnum itemCategory,
                string locale,
                Uri redirectUrl,
                PayPalShipping shipping,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.paypal,
                    MethodEnum.ppcp,
                    new PayPalPPCPPaymentParameters
                    (
                        description,
                        designatedMerchantId,
                        itemCategory,
                        locale,
                        redirectUrl,
                        shipping
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
