using PingPayments.PaymentsApi.Payments.Shared.V1;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class Swish
        {
            /// <summary>
            /// A swish payment with a designated phone number. The old e-commerce way.
            /// </summary>
            public static InitiatePaymentRequest Ecommerce
            (
                IEnumerable<OrderItem> orderItems,
                string phoneNumber,
                string message,
                Uri statusCallbackUrl,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
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
            public static InitiatePaymentRequest Mcommerce
            (
                IEnumerable<OrderItem> orderItems,
                string message,
                Uri statusCallbackUrl,
                SwishQrCode? swishQrCode = null,
                IDictionary<string, dynamic>? metadata = null
            ) => new
                (
                    CurrencyEnum.SEK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.swish,
                    MethodEnum.m_commerce,
                    new SwishMCommerceParameters(message, swishQrCode),
                    statusCallbackUrl,
                    metadata
                );
        }       
    }
}
