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

        /// <summary>
        /// A swish payment with a designated phone number. The old e-commerce way.
        /// </summary>
        public static InitiatePaymentRequest NewSwishEcommerce
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
                MethodEnum.e_commerce,
                new SwishECommerceParameters(phoneNumber, message),
                statusCallbackUrl,
                metadata
            );

        /// <summary>
        /// A swish payment without a designated phone number. 
        /// The payer needs to either be redirected to the swish app using the swish url or scan a swish qr code inside the swish app.
        /// The QR Code is optional, because in an native app scenario the qr code is most likely unnccessary.
        /// </summary>
        public static InitiatePaymentRequest NewSwishMcommerce
        (
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            string message,            
            Uri statusCallbackUrl,
            SwishQrCode? swishQrCode = null,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.SEK,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.swish,
                MethodEnum.m_commerce,
                new SwishMCommerceParameters(message, swishQrCode),
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
        
        public static InitiatePaymentRequest NewPingDepositOCR
        (
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            PingDepositReferenceTypesEnum referenceType,
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.SEK,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.ping,
                MethodEnum.deposit,
                new PingDepositParameters(referenceType),
                statusCallbackUrl,
                metadata
            );

        public static InitiatePaymentRequest NewPingDepositKID
        (
            int totalAmountInMinorCurrency,
            IEnumerable<OrderItem> orderItems,
            PingDepositReferenceTypesEnum referenceType,
            Uri statusCallbackUrl,
            IDictionary<string, dynamic>? metadata = null
        ) => new
            (
                CurrencyEnum.NOK,
                totalAmountInMinorCurrency,
                orderItems,
                ProviderEnum.ping,
                MethodEnum.deposit,
                new PingDepositParameters(referenceType),
                statusCallbackUrl,
                metadata
            );
    }
}
