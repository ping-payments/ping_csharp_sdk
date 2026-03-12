using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Klarna
        {
            public static InitiatePaymentRequest Hpp
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                Uri statusCallbackUrl,
                Guid designatedMerchantId,
                KlarnaHppOptions? hppOptions,
                string locale,
                string merchantReference,
                string purchaseCountry,
                KlarnaRedirectUrls redirectUrls,
                KlarnaAddress? billingAddress = null,
                KlarnaAddress? shippingAddress = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.klarna,
                    MethodEnum.hpp,
                    new KlarnaProviderMethodParameters
                    (
                        billingAddress,
                        designatedMerchantId,
                        hppOptions,
                        locale,
                        merchantReference,
                        purchaseCountry,
                        redirectUrls,
                        shippingAddress
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
