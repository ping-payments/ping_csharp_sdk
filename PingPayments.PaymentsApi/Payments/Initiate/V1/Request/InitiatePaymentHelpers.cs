using PingPayments.PaymentsApi.Helpers;
using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    /// <summary>
    /// Some curated helpers for users of the SDK to use in order to speed up integration or minimize api errors
    /// </summary>
    public static class InitiatePaymentHelpers
    {
        public static int TotalAmountMinorCurrency(this IEnumerable<OrderItem> orderItems) => orderItems.Sum(o => o.Amount);

        public static decimal TotalAmountInCurrency(this IEnumerable<OrderItem> orderItems) => orderItems.Sum(o => o.Amount).FromMinorCurrency();

        public static InitiatePaymentRequest NewDummy
        (
            CurrencyEnum currency,
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            Uri statusCallbackUrl,
            PaymentStatusEnum desiredPaymentStatus = PaymentStatusEnum.COMPLETED,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                currency,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.dummy,
                MethodEnum.dummy,
                new DummyProviderMethodParameters(desiredPaymentStatus),
                statusCallbackUrl,
                metadata
            );


        public static InitiatePaymentRequest NewSwishMobile
        (
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            string phoneNumber,
            string message,
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.SEK,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.swish,
                MethodEnum.mobile,
                new SwishProviderMethodParameters(phoneNumber, message),
                statusCallbackUrl,
                metadata
            );

        public static InitiatePaymentRequest NewBillmateInvoice
        (
            int totalAmountInMinorCurrency,
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
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.SEK,
                totalAmountInMinorCurrency,
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
                metadata
            );

        public static InitiatePaymentRequest NewVerifoneCard
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

        public static InitiatePaymentRequest NewPaymentIqCard
        (
            CurrencyEnum currency,
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            Uri successUrl,
            Uri cancelUrl,
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                currency,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.payment_iq,
                MethodEnum.card,
                new PaymentIqProviderMethodParameters
                (
                    successUrl,
                    cancelUrl
                ),
                statusCallbackUrl,
                metadata
            );       
        
        public static InitiatePaymentRequest NewPaymentIqVipps
        (
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            Uri successUrl,
            Uri cancelUrl,
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.NOK,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.payment_iq,
                MethodEnum.vipps,
                new PaymentIqProviderMethodParameters
                (
                    successUrl,
                    cancelUrl
                ),
                statusCallbackUrl,
                metadata
            );
    }
}
