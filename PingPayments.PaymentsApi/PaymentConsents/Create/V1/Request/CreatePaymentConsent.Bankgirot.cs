using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.PaymentConsents.Create.V1.Request
{
    public static partial class CreatePaymentConsent
    {
        public static class Bankgirot
        {
            public static CreatePaymentConsentRequest Autogiro
            (
                string flow,
                LegalEntity? accountHolder = null,
                Uri? cancelUrl = null,
                Uri? errorUrl = null,
                string? locale = "sv-SE",
                string? mandateDescription = null,
                Uri? successUrl = null,
                Payer? signee = null,
                Uri? statusCallbackUrl = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
            (
                flow,
                ProviderEnum.bankgirot,
                MethodEnum.autogiro,
                new BankgirotAutogiroMandateParameters(accountHolder, cancelUrl, errorUrl, locale, mandateDescription, successUrl),
                signee,
                statusCallbackUrl,
                metadata
            );
        }
    }
}
