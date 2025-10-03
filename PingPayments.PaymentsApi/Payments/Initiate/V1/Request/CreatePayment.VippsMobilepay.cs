using PingPayments.PaymentsApi.Payments.Shared.V1;
using PingPayments.Shared.Enums;
using System;
using System.Collections.Generic;

namespace PingPayments.PaymentsApi.Payments.V1.Initiate.Request
{
    public static partial class CreatePayment
    {
        public static class VippsMobilePay
        {
            public static InitiatePaymentRequest MobilePay
            (
                IEnumerable<OrderItem> orderItems,
                Uri returnUrl,
                Uri statusCallbackUrl,
                string paymentDescription,
                IDictionary<string, dynamic>? metadata = null,
                VippsCustomer? customer = null
            ) => new
                (
                    CurrencyEnum.NOK,
                    orderItems.TotalAmountMinorCurrencyUnit(),
                    orderItems,
                    ProviderEnum.vipps_mobilepay,
                    MethodEnum.checkout,
                    new VippsProviderMethodParameters
                    (
                        paymentDescription,
                        returnUrl,
                        new VippsCustomer
                        {
                            Email = customer?.Email,
                            FirstName = customer?.FirstName,
                            LastName = customer?.LastName,
                            PhoneNumber = customer?.PhoneNumber,
                            City = customer?.City,
                            PostalCode = customer?.PostalCode,
                            Street = customer?.Street,
                            Country = customer?.Country
                        }
                    ),
                    statusCallbackUrl,
                    metadata
                );
        }
    }
}
