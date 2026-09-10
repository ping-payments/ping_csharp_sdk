using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.PaymentsApi.Payments.V1.Initiate.Request;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request
{
    public static partial class CreatePaymentConsent
    {
        public static class Swish
        {
            public static CreatePaymentConsentRequest Recurring
            (
                string flow,
                string tin,
                Payer? signee = null,
                SwishQrCode? swishQrCode = null,
                string? phoneNumber = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
            (
                flow,
                ProviderEnum.swish,
                MethodEnum.recurring,
                new SwishRecurringConsentParameters(tin, phoneNumber ?? signee?.PhoneNumber, swishQrCode),
                signee,
                statusCallbackUrl,
                metadata
            );
        }
    }
}
