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
                Uri redirectUrl,
                Guid designatedMerchantId,
                string? paymentText = null,
                bool framed = false,
                string? language = null,
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
                        designatedMerchantId,
                        paymentText,
                        framed,
                        language
                    ),
                    statusCallbackUrl,
                    metadata,
                    payer
                );
        }
    }
}
