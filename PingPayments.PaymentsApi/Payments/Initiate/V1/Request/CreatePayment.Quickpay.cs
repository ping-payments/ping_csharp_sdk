using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class QuickPay
        {
            public static InitiatePaymentRequest Vipps
            (
                CurrencyEnum currency,
                IEnumerable<OrderItem> orderItems,
                string redirectUrl,
                string? paymentText = null,
                bool framed = false,
                string? language = null,
                string? designatedMerchantId = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null,
                Payer? payer = null
            ) => new
                (
                    currency,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.quickpay,
                    MethodEnum.vipps,
                    new QuickPayVippsParameters
                    (
                        redirectUrl,
                        paymentText,
                        framed,
                        language,
                        designatedMerchantId
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
